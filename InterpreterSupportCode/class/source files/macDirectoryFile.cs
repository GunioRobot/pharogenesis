macDirectoryFile

	^ '/* Adjustments for pluginized VM
 *
 * Note: The Mac support files have not yet been fully converted to
 * pluginization. For the time being, it is assumed that they are linked
 * with the VM. When conversion is complete, they will no longer import
 * "sq.h" and they will access all VM functions and variables through
 * the interpreterProxy mechanism.
 */

#include "sq.h"
#include "FilePlugin.h"

/* End of adjustments for pluginized VM */

#include <Files.h>
#include <Strings.h>

/***
	The interface to the directory primitive is path based.
	That is, the client supplies a Squeak string describing
	the path to the directory on every call. To avoid traversing
	this path on every call, a cache is maintained of the last
	path seen, along with the Mac volume and folder reference
	numbers corresponding to that path.
***/

/*** Constants ***/
#define ENTRY_FOUND     0
#define NO_MORE_ENTRIES 1
#define BAD_PATH        2

#define DELIMITOR '':''
#define MAX_PATH 2000

/*** Variables ***/
char lastPath[MAX_PATH + 1];
int  lastPathValid = false;
int  lastRefNum = 0;
int  lastVolNum = 0;

/*** Functions ***/
int convertToSqueakTime(int macTime);
int equalsLastPath(char *pathString, int pathStringLength);
int lookupPath(char *pathString, int pathStringLength, int *refNumPtr, int *volNumPtr);
int lookupVolume(char *volName, int *refNumPtr);
int recordPath(char *pathString, int pathStringLength, int refNum, int volNum);

int convertToSqueakTime(int macTime) {
	/* Squeak epoch is Jan 1, 1901, 3 non-leap years earlier than Mac one */
	return macTime + (3 * 365 * 24 * 60 * 60);
}

int dir_Create(char *pathString, int pathStringLength) {
	/* Create a new directory with the given path. By default, this
	   directory is created in the current directory. Use
	   a full path name such as "MyDisk:Working:New Folder" to
	   create folders elsewhere. */
	Str255 name;
	HParamBlockRec pb;
	int i;

	if (!plugInAllowAccessToFilePath(pathString, pathStringLength)) {
		return false;
	}

	for (i = 0; i < pathStringLength; i++) {
		name[i] = pathString[i];
	}
	name[i] = 0; /* string terminator */

	CopyCStringToPascal((const char *) name,name);
	pb.fileParam.ioNamePtr = name;
	pb.fileParam.ioVRefNum = 0;
	pb.fileParam.ioDirID = 0;
	return PBDirCreateSync(&pb) == noErr;
}

int dir_Delete(char *pathString, int pathStringLength) {
	/* Delete the existing directory with the given path. */
	int okay, refNum, volNum, i;
	HParamBlockRec pb;
	Str255 name;

	if (!plugInAllowAccessToFilePath(pathString, pathStringLength)) {
		return false;
	}

	for (i = 0; i < pathStringLength; i++) {
		name[i] = pathString[i];
	}
	name[i] = 0; /* string terminator */

	okay = lookupPath(pathString, pathStringLength, &refNum, &volNum);
	if (!okay) {
		return false;
	}

	CopyCStringToPascal((const char *) name,name);
	pb.fileParam.ioNamePtr = name;
	pb.fileParam.ioVRefNum = volNum;
	pb.fileParam.ioDirID = refNum;
	return PBHDeleteSync(&pb) == noErr;
}

int dir_Delimitor(void) {
	return DELIMITOR;
}

int dir_Lookup(char *pathString, int pathStringLength, int index,
  /* outputs: */
  char *name, int *nameLength, int *creationDate, int *modificationDate,
  int *isDirectory, int *sizeIfFile) {
	/* Lookup the index-th entry of the directory with the given path, starting
	   at the root of the file system. Set the name, name length, creation date,
	   creation time, directory flag, and file size (if the entry is a file).
	   Return:	0 	if a entry is found at the given index
	   			1	if the directory has fewer than index entries
	   			2	if the given path has bad syntax or does not reach a directory
	*/

	int okay, newRefNum, newVolNum;
	HVolumeParam volumeParams;
	CInfoPBRec dirParams;

	/* default return values */
	*name             = 0;
	*nameLength       = 0;
	*creationDate     = 0;
	*modificationDate = 0;
	*isDirectory      = false;
	*sizeIfFile       = 0;

	if (!plugInAllowAccessToFilePath(pathString, pathStringLength)) {
		return NO_MORE_ENTRIES;
	}

	if ((pathStringLength == 0)) {
		/* get volume info */
		volumeParams.ioNamePtr = (unsigned char *) name;
		volumeParams.ioVRefNum = 0;
		volumeParams.ioVolIndex = index;
		okay = PBHGetVInfoSync((HParmBlkPtr) &volumeParams) == noErr;
		if (okay) {
			CopyPascalStringToC((ConstStr255Param) name,name);
			*nameLength       = strlen(name);
			*creationDate     = convertToSqueakTime(volumeParams.ioVCrDate);
			*modificationDate = convertToSqueakTime(volumeParams.ioVLsMod);
			*isDirectory      = true;
			*sizeIfFile       = 0;
			return ENTRY_FOUND;
		} else {
			return NO_MORE_ENTRIES;
		}
	} else {
		/* get file or directory info */
		if (!equalsLastPath(pathString, pathStringLength)) {
			/* lookup and cache the refNum for this path */
			okay = lookupPath(pathString, pathStringLength, &newRefNum, &newVolNum);
			if (okay) {
				recordPath(pathString, pathStringLength, newRefNum, newVolNum);
			} else {
				return BAD_PATH;
			}
		}
		dirParams.hFileInfo.ioNamePtr = (unsigned char *) name;
		dirParams.hFileInfo.ioFVersNum = 0;
		dirParams.hFileInfo.ioFDirIndex = index;
		if (lastRefNum < 0) {
			dirParams.hFileInfo.ioVRefNum = lastRefNum;
			dirParams.hFileInfo.ioDirID = 0;
		} else {
			dirParams.hFileInfo.ioVRefNum = lastVolNum;
			dirParams.hFileInfo.ioDirID = lastRefNum;
		}
		okay = PBGetCatInfoSync(&dirParams) == noErr;
		if (okay) {
			CopyPascalStringToC((ConstStr255Param) name,name);
			*nameLength       = strlen(name);
			*creationDate     = convertToSqueakTime(dirParams.hFileInfo.ioFlCrDat);
			*modificationDate = convertToSqueakTime(dirParams.hFileInfo.ioFlMdDat);
			if ((dirParams.hFileInfo.ioFlAttrib & 16) != 0) {
				*isDirectory  = true;
				*sizeIfFile   = 0;
			} else {
				*isDirectory  = false;
				*sizeIfFile   = dirParams.hFileInfo.ioFlLgLen;
			}
			return ENTRY_FOUND;
		} else {
			return NO_MORE_ENTRIES;
		}
	}
}

dir_SetMacFileTypeAndCreator(char *filename, int filenameSize, char *fType, char *fCreator) {
	/* Set the Macintosh type and creator of the given file. */
	/* Note: On other platforms, this is just a noop. */

	Str255 name;
	FInfo finderInfo;
	int i;

	/* copy file name into a Pascal string */
	if (filenameSize > 255) return false;
	name[0] = filenameSize;
	for (i = 1; i <= filenameSize; i++) {
		name[i] = filename[i - 1];
	}

	if (HGetFInfo(0,0,name,  &finderInfo) != noErr) return false;
	finderInfo.fdType = *((int *) fType);
	finderInfo.fdCreator = *((int *) fCreator);
	if (HSetFInfo(0,0,name,  &finderInfo) != noErr) return false;
	return true;
}

dir_GetMacFileTypeAndCreator(char *filename, int filenameSize, char *fType, char *fCreator) {
	/* Get the Macintosh type and creator of the given file. */
	/* Note: On other platforms, this is just a noop. */

	Str255 name;
	FInfo finderInfo;
	int i;

	/* copy file name into a Pascal string */
	if (filenameSize > 255) return false;
	name[0] = filenameSize;
	for (i = 1; i <= filenameSize; i++) {
		name[i] = filename[i - 1];
	}

	if (HGetFInfo(0,0,name,  &finderInfo) != noErr) return false;
	*((int *) fType) = finderInfo.fdType;
	*((int *) fCreator) = finderInfo.fdCreator;

	return true;
}


int equalsLastPath(char *pathString, int pathStringLength) {
	/* Return true if the lastPath cache is valid and the
	   given Squeak string equals it. */

	int i, ch;

	if (!lastPathValid ||
		(pathStringLength > MAX_PATH)) {
			return false;
	}

	for (i = 0; i < pathStringLength; i++) {
		ch = lastPath[i];
		if ((ch == 0) || (ch != pathString[i])) return false;
	}
	return lastPath[i] == 0;
}


/*
Note:
The previous version of lookupPath checks each folder in the path
hierarchy.  Given a parent folder id of 0, the Carbon version wants
to look in the default directory rather than the root level.  So, rather
than fix it up, I chose to rewrite the function, first looking for the
volume, then the directory (they are the system calls offered anyway).

The function only needs to return false for failure otherwise the volume
and folder id numbers - not details of a full examination of the path.

Karl Goiser 14/01/01
*/

int lookupPath(char *pathString, int pathStringLength, int *refNumPtr, int *volNumPtr) {
	/* Resolve the given path and return the resulting folder or volume
	   reference number in *refNumPtr. Return false if the path is bad. */


	Str255		tempName;
	CInfoPBRec	pb;
	OSErr		err;
    FSSpec		volumeSpec;
    long        i;

	// Set up for failure...
		*refNumPtr = 0;
		*volNumPtr = 0;


// --------------
// Find the volume reference number:

	/* copy file name into a Pascal string */
	if (pathStringLength > 255) return false;
	
	tempName[0] = pathStringLength;
	for (i = 1; i <= pathStringLength; i++)
		tempName[i] = pathString[i - 1];


	err = FSMakeFSSpec (0, 0, tempName, &volumeSpec);
	if (err == -43) {
	    err = lookupVolume(pathString, refNumPtr);
	    return err;
	}
	
	if (err != noErr) {
	    return false;
	}


// --------------
// Find the directory id:

	pb.hFileInfo.ioFDirIndex = 0;
	pb.hFileInfo.ioNamePtr = tempName;
	pb.hFileInfo.ioVRefNum = 0;
	pb.hFileInfo.ioDirID = 0;
	pb.hFileInfo.ioACUser = 0; /* ioACUser used to be filler2 */
	pb.hFileInfo.ioCompletion = nil;
	pb.hFileInfo.ioFVersNum = 0;

	err = PBGetCatInfoSync(&pb);
	if (err != noErr) return false;

	*refNumPtr = pb.hFileInfo.ioDirID;
	*volNumPtr = volumeSpec.vRefNum;

	return true;
}


int lookupVolume(char *volName, int *refNumPtr) {
	/* Look up the volume with the given name and set *refNumPtr
	   to the reference number of the resulting volume.
	   Return true if this succeeds. */

	int okay;
	HVolumeParam volumeParams;
	Str255 tempVolName;

	CopyCStringToPascal((const char *)volName,tempVolName);
	volumeParams.ioNamePtr = (StringPtr) tempVolName;
	volumeParams.ioVRefNum = 0;
	volumeParams.ioVolIndex = -1;
	okay = PBHGetVInfoSync((HParmBlkPtr) &volumeParams) == noErr;

	if (okay) {
		*refNumPtr = volumeParams.ioVRefNum;
		return true;
	}
	return false;
}

int recordPath(char *pathString, int pathStringLength, int refNum, int volNum) {
	/* Copy the given Squeak string into the lastPath cache. */

	int i;

	if (pathStringLength > MAX_PATH) {
		lastPath[0] = 0; /* set to empty string */
		lastPathValid = false;
		lastRefNum = 0;
		lastVolNum = 0;
		return;
	}
	for (i = 0; i < pathStringLength; i++) {
		lastPath[i] = pathString[i];
	}
	lastPath[i] = 0; /* string terminator */
	lastPathValid = true;
	lastRefNum = refNum;
	lastVolNum = volNum;
}

'