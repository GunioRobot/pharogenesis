macDirectoryFile

	^ '#include <Files.h>
#include <Strings.h>
#include "sq.h"

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
int lookupDirectory(int volRefNum, int folderRefNum, char *name, int *refNumPtr);
int lookupPath(char *pathString, int pathStringLength, int *refNumPtr, int *volNumPtr);
int lookupVolume(char *volName, int *refNumPtr);
int prefixPathWith(char *pathName, int pathNameSize, int pathNameMax, char *prefix);
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

	for (i = 0; i < pathStringLength; i++) {
		name[i] = pathString[i];
	}
	name[i] = 0; /* string terminator */
	c2pstr((char *) name);

	pb.fileParam.ioNamePtr = name;
	pb.fileParam.ioVRefNum = 0;
	pb.fileParam.ioDirID = 0;
	return PBDirCreateSync(&pb) == noErr;
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

	if ((pathStringLength == 0)) {
		/* get volume info */
		volumeParams.ioNamePtr = (unsigned char *) name;
		volumeParams.ioVRefNum = 0;
		volumeParams.ioVolIndex = index;
		okay = PBHGetVInfoSync((HParmBlkPtr) &volumeParams) == noErr;
		if (okay) {
			p2cstr((unsigned char *) name);
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
			p2cstr((unsigned char *) name);
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

int dir_PathToWorkingDir(char *pathName, int pathNameMax) {
	/* Fill in the given string with the full path from a root volume to
	   to current working directory. (At startup time, the working directory
	   is set to the application''s directory. Fails if the given string is not
	   long enough to hold the entire path. (Use at least 1000 characters to
	   be safe.)
	*/

	char thisName[256];
	CInfoPBRec pb;
	int nextDirRefNum, pathLen;

	/* initialize string copying state */
	pathName[0] = 0;
	pathLen = 0;

	/* get refNum of working directory */
	strcpy(thisName, ":");
	pb.hFileInfo.ioNamePtr = c2pstr(thisName);
	pb.hFileInfo.ioVRefNum = 0;
	pb.hFileInfo.ioFDirIndex = 0;
	pb.hFileInfo.ioDirID = 0;
	if (PBGetCatInfoSync(&pb) != noErr) {
		nextDirRefNum = 0;
	}
	nextDirRefNum = pb.hFileInfo.ioDirID;

	while (true) {
		thisName[0] = 0;
		pb.hFileInfo.ioFDirIndex = -1; /* map ioDirID -> name */
		pb.hFileInfo.ioVRefNum = 0;
		pb.hFileInfo.ioDirID = nextDirRefNum;
		if (PBGetCatInfoSync(&pb) != noErr) {
			break;  /* we''ve reached the root */
		}
		p2cstr((unsigned char *) thisName);
		pathLen = prefixPathWith(pathName, pathLen, pathNameMax, thisName);
		nextDirRefNum = pb.dirInfo.ioDrParID;
	}
	return pathLen;
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

	if (GetFInfo(name, 0, &finderInfo) != noErr) return false;
	finderInfo.fdType = *((int *) fType);
	finderInfo.fdCreator = *((int *) fCreator);
	if (SetFInfo(name, 0, &finderInfo) != noErr) return false;
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

int lookupDirectory(int volRefNum, int folderRefNum, char *name, int *refNumPtr) {
	/* Look up the next directory in a path starting from the folder and volume
	   with the given reference numbers and setting *refNumPtr to the reference
	   number of the resulting folder. Return true if this succeeds. */

	CInfoPBRec pb;

	c2pstr((char *) name);
	pb.hFileInfo.ioNamePtr = (unsigned char *) name;
	pb.hFileInfo.ioFVersNum = 0;
	pb.hFileInfo.ioFDirIndex = 0;
	pb.hFileInfo.ioVRefNum = volRefNum;
	pb.hFileInfo.ioDirID = folderRefNum;

	if (PBGetCatInfoSync(&pb) == noErr) {
		p2cstr((unsigned char *) name);
		*refNumPtr = pb.hFileInfo.ioDirID;
		return true;
	}
	p2cstr((unsigned char *) name);
	return false;
}

int lookupPath(char *pathString, int pathStringLength, int *refNumPtr, int *volNumPtr) {
	/* Resolve the given path and return the resulting folder or volume
	   reference number in *refNumPtr. Return false if the path is bad. */

	char chunk[100];
	int stIndex, chunkIndex, ch;
	int okay, thisVolNum = 0, thisRefNum = 0;
	int firstChunk = true, hasLeadingDelimitors = false;

	stIndex = 0;
	while (stIndex < pathStringLength) {
		chunkIndex = 0;

		while ((stIndex < pathStringLength) && (pathString[stIndex] == DELIMITOR)) {
			/* copy any leading delimitors */
			chunk[chunkIndex++] = pathString[stIndex++];
			hasLeadingDelimitors = true;
		}

		while ((stIndex < pathStringLength) && (pathString[stIndex] != DELIMITOR)) {
			/* copy up to the next delimitor */
			ch = chunk[chunkIndex++] = pathString[stIndex++];
		}

		if (firstChunk && (chunk[chunkIndex] != DELIMITOR)) {
			/* Add a trailing delimiter to the first chunk of the
			   path to indicate that it is a volume name. If the
			   path starts with an initial delimitor, it will be
			   interpreted as a path relative to the current working
			   directory even with a trailing delimitor, which is
			   exactly the behavior we want. */
			chunk[chunkIndex++] = DELIMITOR;
			if ((stIndex < pathStringLength) && (pathString[stIndex] == DELIMITOR)) {
				stIndex++;
			}
			firstChunk = false;
		}
		chunk[chunkIndex] = 0;  /* terminate this chunk */

		if ((thisVolNum == 0) && !hasLeadingDelimitors) {
			okay = lookupVolume(chunk, &thisVolNum);
			thisRefNum = 0;
		} else {
			okay = lookupDirectory(thisVolNum, thisRefNum, chunk, &thisRefNum);
		}
		if (!okay) {
			*refNumPtr = 0;
			*volNumPtr = 0;
			return false;
		}
	}
	*refNumPtr = thisRefNum;
	*volNumPtr = thisVolNum;
	return true;
}

int lookupVolume(char *volName, int *refNumPtr) {
	/* Look up the volume with the given name and set *refNumPtr
	   to the reference number of the resulting volume.
	   Return true if this succeeds. */

	int okay;
	HVolumeParam volumeParams;

	volumeParams.ioNamePtr = c2pstr(volName);
	volumeParams.ioVRefNum = 0;
	volumeParams.ioVolIndex = -1;
	okay = PBHGetVInfoSync((HParmBlkPtr) &volumeParams) == noErr;
	p2cstr((unsigned char *) volName);
	if (okay) {
		*refNumPtr = volumeParams.ioVRefNum;
		return true;
	}
	return false;
}

int prefixPathWith(char *pathName, int pathNameSize, int pathNameMax, char *prefix) {
	/* Insert the given prefix C string plus a delimitor character at the
	   beginning of the given C string. Return the new pathName size. Fails
	   if pathName is does not have sufficient space for the result.
	   Assume: pathName is null terminated.
	*/

	int offset, i;

	offset = strlen(prefix) + 1;
	if ((pathNameSize + offset) > pathNameMax) {
		error("path name to working directory is too long for available space");
	}

	for (i = pathNameSize; i >= 0; i--) {
		/* make room in pathName for prefix (moving string terminator, too) */
		pathName[i + offset] = pathName[i];
	}
	for (i = 0; i < offset; i++) {
		/* make room in pathName for prefix */
		pathName[i] = prefix[i];
	}
	pathName[offset - 1] = DELIMITOR;  /* insert delimitor */
	return pathNameSize + offset;
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

'.
