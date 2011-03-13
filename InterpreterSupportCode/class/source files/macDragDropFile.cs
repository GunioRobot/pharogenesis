macDragDropFile
	^ '/*  Jan 24th 2001
	Drag and drop support for Squeak 
	John M McIntosh of Corporate Smalltalk Consulting Ltd
	johnmci@smalltalkconsulting.com 
	http://www.smalltalkconsulting.com 
	In Jan of 2001 under contract to Disney
	
	Dragging is only for objects into Squeak, not from Squeak outwards.
		
    V1.0 Jan 24th 2001, JMM


Some of this code comes from
	Author:		John Montbriand
				Some techniques borrowed from Pete Gontier''s original FinderDragPro.


	Copyright: 	Copyright: � 1999 by Apple Computer, Inc.
				all rights reserved.
	
	Disclaimer:	You may incorporate this sample code into your applications without
				restriction, though the sample code has been provided "AS IS" and the
				responsibility for its operation is 100% yours.  However, what you are
				not permitted to do is to redistribute the source as "DSC Sample Code"
				after having made changes. If you''re going to re-distribute the source,
				we require that you make it clear in the source that the code was
				descended from Apple Sample Code, but that you''ve made changes.
	
	Change History (most recent first):
	9/9/99 by John Montbriand
	
*/
/*
    need get filetype/creator
    need DropPlugin_shutdownModule & dropShutdown
    
*/

#include "sq.h"

#include <drag.h>
#include <macwindows.h>
#include <gestalt.h>
#include <quickdraw.h>


#include "sqVirtualMachine.h"
#include "FilePlugin.h"

#include "DropPlugin.h"

#if TARGET_API_MAC_CARBON
#else
    inline Rect *GetPortBounds(CGrafPtr w,Rect *r) { *r = w->portRect; return &w->portRect;}  
#endif

	/* promise flavor types */
	
enum {
	kPromisedFlavor = ''fssP'',		/* default promise */
	kPromisedFlavorFindFile = ''rWm1'' /* Find File promise -- special case */
};


 Boolean gHasDragManager = false;                    /* true if the Drag Manager is installed */
 Boolean gCanTranslucentDrag = false;                /* true if translucent dragging is available */
 DragReceiveHandlerUPP gMainReceiveHandler = NULL;   /* receive handler for the main dialog */
 DragTrackingHandlerUPP gMainTrackingHandler = NULL; /* tracking handler for the main dialog */
 WindowPtr   gWindowPtr;

 UInt16 gNumDropFiles=0;
 HFSFlavor *dropFiles;

#define DOCUMENT_NAME_SIZE 300
char tempName[DOCUMENT_NAME_SIZE + 1];  

	/* these routines are used both in the receive handler and inside of the
		tracking handler.  The following variables are shared between MyDragTrackingHandler
		and MyDragReceiveHandler.  */
		
 Boolean gApprovedDrag = false;   /* set to true if the drag is approved */
 Boolean gInIconBox = false;      /* set true if the drag is inside our drop box */


extern struct VirtualMachine *interpreterProxy;
extern WindowPtr getSTWindow(void);
 pascal OSErr MyDragTrackingHandler(DragTrackingMessage message, WindowPtr theWindow, void *refCon, DragReference theDragRef);
 pascal OSErr MyDragReceiveHandler(WindowPtr theWindow, void *refcon, DragReference theDragRef);

extern int (*instantiateClassindexableSize)(int classPointer, int size);
extern int classByteArray(void);
extern int fileRecordSize(void);
extern int sqFileOpen(SQFile *f, int sqFileNameIndex, int sqFileNameSize, int writeFlag);
extern SQFile * fileValueOf(int objectPointer);
extern int recordDragDropEvent(EventRecord *theEvent, int theButtonState, int numberOfItems, int dragType);
extern int MouseModifierState(EventRecord *theEvent);
extern void StoreFullPathForLocalNameInto(char *shortName, char *fullName, int length, short VolumeNumber,long directoryID);

// Startup logic

int dropInit(void)
{
    long response;
    long fn;
    Boolean  installedReceiver=false, installedTracker=false;
    OSErr err;
    
    /* check for the drag manager & translucent feature??? */
    
	if (gMainReceiveHandler != NULL) return 1;
	
	if (Gestalt(gestaltDragMgrAttr, &response) != noErr) return 0;
	
	gHasDragManager = (((1 << gestaltDragMgrPresent)) != 0);
	gCanTranslucentDrag = (((1 << gestaltDragMgrHasImageSupport)) != 0);

    if (!(gHasDragManager && gCanTranslucentDrag)) return 0;
	
	gWindowPtr = getSTWindow();

	gMainTrackingHandler = NewDragTrackingHandlerUPP(MyDragTrackingHandler);
	if (gMainTrackingHandler == NULL) return 0;
	gMainReceiveHandler = NewDragReceiveHandlerUPP(MyDragReceiveHandler);
	if (gMainReceiveHandler == NULL) return 0;

		/* install the drag handlers, don''t forget to dispose of them later */
		
	err = InstallTrackingHandler(gMainTrackingHandler, gWindowPtr, NULL);
	if (err != noErr) { 
	    err = memFullErr; 
	    goto bail; 
    }
	installedTracker = true;
	err = InstallReceiveHandler(gMainReceiveHandler, gWindowPtr, NULL);
	
	if (err != noErr) { 
	    err = memFullErr; 
	    goto bail; 
	}
	installedReceiver = true;
	return 1;
	
bail: 
    if (installedReceiver)
		RemoveReceiveHandler(gMainReceiveHandler, gWindowPtr);
	if (installedTracker)
		RemoveTrackingHandler(gMainTrackingHandler, gWindowPtr);
	
	gMainTrackingHandler = NULL; 
    gMainReceiveHandler = NULL;
    
	return 0;
}	

// Shutdown logic

int dropShutdown() {
    if (gMainReceiveHandler != NULL)
		RemoveReceiveHandler(gMainReceiveHandler, gWindowPtr);
	if (gMainTrackingHandler != NULL)
		RemoveTrackingHandler(gMainTrackingHandler, gWindowPtr);
	if (gNumDropFiles != 0 ) {
	    DisposePtr((char *) dropFiles);
	    gNumDropFiles = 0;
	}
	
	gMainTrackingHandler = NULL; 
    gMainReceiveHandler = NULL;

}

//Primitive to get file name

char *dropRequestFileName(int dropIndex) {
    char	shortName[256];
  
    if(dropIndex < 1 || dropIndex > gNumDropFiles) 
        return NULL;
    CopyPascalStringToC(dropFiles[dropIndex-1].fileSpec.name,shortName);
    StoreFullPathForLocalNameInto(shortName, 
        tempName, 
        DOCUMENT_NAME_SIZE,
        dropFiles[dropIndex-1].fileSpec.vRefNum,
        dropFiles[dropIndex-1].fileSpec.parID);
  return tempName;
}

//Primitive to get file stream handle.

int dropRequestFileHandle(int dropIndex) {
    int fileHandle;
    int   size,classPointer;
    char *dropName = dropRequestFileName(dropIndex);
    
    if(!dropName)
        return interpreterProxy->nilObject();

    size = fileRecordSize();
    classPointer = interpreterProxy->classByteArray();
    fileHandle = interpreterProxy->instantiateClassindexableSize(classPointer, size);
    sqFileOpen(fileValueOf(fileHandle),(int)dropName, strlen(dropName), 0);
    
  return fileHandle;
}


/* RECEIVING DRAGS ------------------------------------------------ */


/* ApproveDragReference is called by the drag tracking handler to determine
	if the contents of the drag can be handled by our receive handler.

	Note that if a flavor can''t be found, it''s not really an
	error; it only means the flavor wasn''t there and we should
	not accept the drag. Therefore, we translate ''badDragFlavorErr''
	into a ''false'' value for ''*approved''. */
	
static pascal OSErr ApproveDragReference(DragReference theDragRef, Boolean *approved) {

	OSErr err;
	DragAttributes dragAttrs;
	FlavorFlags flavorFlags;
	ItemReference theItem;
		
		/* we cannot drag to our own window */
	if ((err = GetDragAttributes(theDragRef, &dragAttrs)) != noErr) 
	    goto bail;
	    
	if ((dragAttrs & kDragInsideSenderWindow) != 0) { 
	    err = userCanceledErr; 
	    goto bail; 
    }
	
		/* gather information about the drag & a reference to item one. */
	if ((err = GetDragItemReferenceNumber(theDragRef, 1, &theItem)) != noErr) 
	    goto bail;
		
		/* check for flavorTypeHFS */
	err = GetFlavorFlags(theDragRef, theItem, flavorTypeHFS, &flavorFlags);
	if (err == noErr) {
		*approved = true;
		return noErr;
	} else if (err != badDragFlavorErr)
		goto bail;
		
		/* check for flavorTypePromiseHFS */
	err = GetFlavorFlags(theDragRef, theItem, flavorTypePromiseHFS, &flavorFlags);
	if (err == noErr) {
		*approved = true;
		return noErr;
	} else if (err != badDragFlavorErr)
		goto bail;
		
		/* none of our flavors were found */
	*approved = false;
	return noErr;
	
bail:
		/* an error occured, clean up.  set result to false. */
	*approved = false;
	return err;
}



/* MyDragTrackingHandler is called for tracking the mouse while a drag is passing over our
	window.  if the drag is approved, then the drop box will be hilitied appropriately
	as the mouse passes over it.  */
	
static pascal OSErr MyDragTrackingHandler(DragTrackingMessage message, WindowPtr theWindow, void *refCon, DragReference theDragRef) {
		/* we''re drawing into the image well if we hilite... */
    Rect  bounds;
	EventRecord		theEvent;

	switch (message) {
	
		case kDragTrackingEnterWindow:
			{	
				Point mouse;
				
				gApprovedDrag = false;
				if (theWindow == gWindowPtr) {
					if (ApproveDragReference(theDragRef, &gApprovedDrag) != noErr) break;
					if ( ! gApprovedDrag ) break;
					SetPortWindowPort(theWindow);
					GetMouse(&mouse);
					GetPortBounds(GetWindowPort(gWindowPtr),&bounds);
					if (PtInRect(mouse, &bounds)) {  // if we''re in the box, hilite... 
						gInIconBox = true;					
                    	    /* queue up an event */
                        WaitNextEvent(0, &theEvent,0,null);
                    	recordDragDropEvent(&theEvent, MouseModifierState(&theEvent),gNumDropFiles,DragEnter);
					} 
				}
			}
			break;

		case kDragTrackingInWindow:
			if (gApprovedDrag) {
                WaitNextEvent(0, &theEvent,0,null);
            	recordDragDropEvent(&theEvent, MouseModifierState(&theEvent),gNumDropFiles,DragMove);
			}
			break;

		case kDragTrackingLeaveWindow:
			if (gApprovedDrag && gInIconBox) {
            	    /* queue up an event */
                WaitNextEvent(0, &theEvent,0,null);
            	recordDragDropEvent(&theEvent, MouseModifierState(&theEvent),gNumDropFiles,DragLeave);
			}
			gApprovedDrag = gInIconBox = false;
			break;
	}
	return noErr; // there''s no point in confusing Drag Manager or its caller
}


/* MyDragReceiveHandler is the receive handler for the main window.  It is called
	when a file or folder (or a promised file or folder) is dropped into the drop
	box in the main window.  Here, if the drag reference has been approved in the
	track drag call, we handle three different cases:
	
	1. standard hfs flavors,
	
	2. promised flavors provided by find file, mmmm This may be a pre sherlock issue
	
	3. promised flavors provided by other applications.
	
     */
     
static pascal OSErr MyDragReceiveHandler(WindowPtr theWindow, void *refcon, DragReference theDragRef) {

	ItemReference   theItem;
	PromiseHFSFlavor targetPromise;
	Size            theSize;
	OSErr           err;
	EventRecord		theEvent;
	long            i,countActualItems;
	FInfo 			finderInfo;
	HFSFlavor		targetHFSFlavor;
	
		/* validate the drag.  Recall the receive handler will only be called after
		the tracking handler has received a kDragTrackingInWindow event.  As a result,
		the gApprovedDrag and gInIconBox will be defined when we arrive here.  Hence,
		there is no need to spend extra time validating the drag at this point. */
		
	if ( ! (gApprovedDrag && gInIconBox) )  
	    return userCanceledErr; 

	if (gNumDropFiles !=0 ) 
	    DisposePtr((char *) dropFiles);
	    
	if ((err = CountDragItems(theDragRef, &gNumDropFiles)) != noErr) 
	    return paramErr;
	
	dropFiles = (HFSFlavor *) NewPtr(sizeof(HFSFlavor)*gNumDropFiles);
	
	if (dropFiles == null) 
	    return userCanceledErr;
	
    WaitNextEvent(0, &theEvent,0,null);
    countActualItems = 0;
    		
    for(i=1;i<=gNumDropFiles;i++) {
		/* get the first item reference */
    	if ((err = GetDragItemReferenceNumber(theDragRef, i, &theItem)) != noErr) 
    	    continue;

    		/* try to get a  HFSFlavor*/
    	theSize = sizeof(HFSFlavor);
    	err = GetFlavorData(theDragRef, theItem, flavorTypeHFS, &targetHFSFlavor, &theSize, 0);
    	if (err == noErr) {
    		if (dropFiles[countActualItems].fileCreator == ''MACS'' && (
    				dropFiles[countActualItems].fileType == ''fold'' ||
    				dropFiles[countActualItems].fileType == ''disk'')) 
    				continue;
    		dropFiles[countActualItems] = targetHFSFlavor;
    		countActualItems++;
    		continue;
    	} else if (err != badDragFlavorErr) 
    	        continue; 
    	
    		/* try to get a  promised HFSFlavor*/
    	theSize = sizeof(PromiseHFSFlavor);
    	err = GetFlavorData(theDragRef, theItem, flavorTypePromiseHFS, &targetPromise, &theSize, 0);
    	if (err != noErr) 
    		continue;
    	
    		/* check for a drop from find file */
    	if (targetPromise.promisedFlavor == kPromisedFlavorFindFile) {
    	
    			/* from find file, no need to set the file location... */
    		theSize = sizeof(FSSpec);
    		err = GetFlavorData(theDragRef, theItem, targetPromise.promisedFlavor, &dropFiles[countActualItems].fileSpec, &theSize, 0);
    		if (err != noErr) 
    			continue;
    		HGetFInfo(dropFiles[countActualItems].fileSpec.vRefNum,dropFiles[countActualItems].fileSpec.parID,dropFiles[countActualItems].fileSpec.name,  &finderInfo);
	    		/* queue up an event */
	        dropFiles[countActualItems].fileType = finderInfo.fdType;
	        dropFiles[countActualItems].fileCreator = finderInfo.fdCreator;
	        dropFiles[countActualItems].fdFlags =  finderInfo.fdFlags;
    		countActualItems++;
    	} else {
    		err = badDragFlavorErr;
    		return err;
    	}
    }
    
	gNumDropFiles = countActualItems;
    if (gNumDropFiles == 0) {
    	DisposePtr((char *) dropFiles);
    	return noErr;
    }
	
	    /* queue up an event */

	recordDragDropEvent(&theEvent, MouseModifierState(&theEvent),gNumDropFiles,DragDrop);
	return noErr;
}

'