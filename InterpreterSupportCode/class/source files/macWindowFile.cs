macWindowFile

	^ '#include "sq.h"

#include <AppleEvents.h>
#include <Dialogs.h>
#include <Devices.h>
#include <Files.h>
#include <Fonts.h>
#include <Gestalt.h>
#include <LowMem.h>
#include <Memory.h>
#include <Menus.h>
#include <OSUtils.h>
#include <Power.h>
#include <QuickDraw.h>
#include <Scrap.h>
#include <Strings.h>
#include <Timer.h>
#include <ToolUtils.h>
#include <Windows.h>
#include <profiler.h>
#include <sound.h>
#include <Math64.h>
#include <cstddef>
#include <processes.h>
#include <OpenTransport.h>

#include <stddef.h>



/*** Compilation Options:
*
*	define PLUGIN		to compile code for Netscape or IE Plug-in
*	define MAKE_PROFILE	to compile code for profiling
*
***/

//#define PLUGIN
//#define MAKE_PROFILE
//#define IHAVENOHEAD

//Aug 7th 2000,JMM Added logic for interrupt driven dispatching
//Sept 1st 2000, JMM fix problem with modifier information being passed back incorrectly.
//Sept 1st 2000, JMM use floating point for time versus 64bit math (faster!)
//Sept 1st 2000, JMM watch mouse movement foreground only, ignore when squeak in background.
//Sept 18th 2000, JMM fix to cmpSize 
//Sept 19th 2000, JMM Sept 1st fix to keyboard modifier info broke cmd shift
//Sept 27 2000, JMM fix to documentPath
//Nov 13 2000, JMM logic to read/write image from VM. 
//Nov 22 2000, JMM Bob Arning found a bug with the duplicate mouse event logic (we were altering the event then recording the altered value)
//Nov 30 2000, JMM Use Open Transport clock versus upTime, solves some issues for jitter and it''s faster
//Dec 5th 2000, JMM poll 60 times a second... do event polling via checkForInterrupts and drive semaphore
//Dec 6th 2000, JMM added logic to interface with power manger (1997 was there but dropped..., back again for ibooks)
//Jan 14th 2001, KG Did some carbon porting.

#if TARGET_API_MAC_CARBON
    #define EnableMenuItemCarbon(m1,v1)  EnableMenuItem(m1,v1);
    #define DisableMenuItemCarbon(m1,v1)  DisableMenuItem(m1,v1);
#else
    #ifndef NewAEEventHandlerUPP
    	#define NewAEEventHandlerUPP NewAEEventHandlerProc 
    #endif
    #define EnableMenuItemCarbon(m1,v1)  EnableItem(m1,v1);
    #define DisableMenuItemCarbon(m1,v1)  DisableItem(m1,v1);
        inline Rect *GetPortBounds(CGrafPtr w,Rect *r) { *r = w->portRect; return &w->portRect;}  
        inline BitMap *GetQDGlobalsScreenBits(BitMap *bm){*bm = qd.screenBits; return &qd.screenBits; }
        inline BitMap * GetPortBitMapForCopyBits (CGrafPtr w) { return &((GrafPtr)w)->portBits;}
        inline pascal long InvalWindowRect(WindowRef  window,  const Rect * bounds) {InvalRect (bounds);}
#endif

/*** Enumerations ***/
enum { appleID = 1, fileID, editID };
enum { quitItem = 1 };

/* The following prototype is missing from the CW11 header files: */
pascal void ExitToShell(void);

/*** Variables -- Imported from Browser Plugin Module ***/
#ifdef PLUGIN
extern int pluginArgCount;
extern char *pluginArgName[100];
extern char *pluginArgValue[100];
#endif

/*** Variables -- Imported from Virtual Machine ***/
extern int fullScreenFlag;
extern int interruptCheckCounter;
extern int interruptKeycode;
extern int interruptPending;  /* set to true by recordKeystroke if interrupt key is pressed */
extern unsigned char *memory;
extern int savedWindowSize;   /* set from header when image file is loaded */

/*** Variables -- image and path names ***/
#define IMAGE_NAME_SIZE 300
char imageName[IMAGE_NAME_SIZE + 1];  /* full path to image file */

#define SHORTIMAGE_NAME_SIZE 100
char shortImageName[SHORTIMAGE_NAME_SIZE + 1];  /* just the image file name */

#define DOCUMENT_NAME_SIZE 300
char documentName[DOCUMENT_NAME_SIZE + 1];  /* full path to document file */

#define VMPATH_SIZE 300
char vmPath[VMPATH_SIZE + 1];  /* full path to interpreter''s directory */

/*** Variables -- Mac Related ***/
MenuHandle		appleMenu = nil;
MenuHandle		editMenu = nil;
int				menuBarHeight = 20;
RgnHandle		menuBarRegion = nil;  /* if non-nil, then menu bar has been hidden */
MenuHandle		fileMenu = nil;
CTabHandle		stColorTable = nil;
PixMapHandle	stPixMap = nil;
WindowPtr		stWindow = nil;
OTTimeStamp     timeStart;
Boolean         gTapPowerManager=false;
Boolean         gDisablePowerManager=false;
const long      gDisableIdleTickCount=60*10;
long            gDisableIdleTickLimit=0;

/*** Variables -- Event Recording ***/
#define MAX_EVENT_BUFFER 1024
int inputSemaphoreIndex = 0;/* if non-zero the event semaphore index */

sqInputEvent eventBuffer[MAX_EVENT_BUFFER];
int eventBufferGet = 0;
int eventBufferPut = 0;

/* declaration of the event message hook */
typedef int (*eventMessageHook)(EventRecord* event);
eventMessageHook messageHook = NULL;
eventMessageHook postMessageHook = NULL;


#define KEYBUF_SIZE 64
int keyBuf[KEYBUF_SIZE];	/* circular buffer */
int keyBufGet = 0;			/* index of next item of keyBuf to read */
int keyBufPut = 0;			/* index of next item of keyBuf to write */
int keyBufOverflows = 0;	/* number of characters dropped */

int buttonState = 0;		/* mouse button and modifier state when mouse
							   button went down or 0 if not pressed */
int cachedButtonState = 0;	/* buffered mouse button and modifier state for
							   last mouse click even if button has since gone up;
							   this cache is kept until the next time ioGetButtonState()
							   is called to avoid missing short clicks */

Point savedMousePosition;	/* mouse position when window is inactive */
int windowActive = true;	/* true if the Squeak window is the active window */

/* This table maps the 5 Macintosh modifier key bits to 4 Squeak modifier
   bits. (The Mac shift and caps lock keys are both mapped to the single
   Squeak shift bit).
		Mac bits: <control><option><caps lock><shift><command>
		ST bits:  <command><option><control><shift>
*/
char modifierMap[32] = {
	0,  8, 1,  9, 1,  9, 1,  9, 4, 12, 5, 13, 5, 13, 5, 13,
	2, 10, 3, 11, 3, 11, 3, 11, 6, 14, 7, 15, 7, 15, 7, 15
};

/*** Functions ***/
void AdjustMenus(void);
void FreeClipboard(void);
void FreePixmap(void);
char * GetAttributeString(int id);
int  HandleEvents(void);
void HandleMenu(int mSelect);
void HandleMouseDown(EventRecord *theEvent);
void InitMacintosh(void);
void InstallAppleEventHandlers(void);
int  IsImageName(char *name);
CFragConnectionID LoadLibViaPath(char *libName, char *pluginDirPath);
void MenuBarHide(void);
void MenuBarRestore(void);
int PathToWorkingDir(char *pathName, int pathNameMax, short volumeNumber,long directoryID);
int PrefixPathWith(char *pathName, int pathNameSize, int pathNameMax, char *prefix);
void SetColorEntry(int index, int red, int green, int blue);
void SetUpClipboard(void);
void SetUpMenus(void);
void SetUpPixmap(void);
void SetUpWindow(void);
void SetWindowTitle(char *title);
void StoreFullPathForLocalNameInto(char *shortName, char *fullName, int length, short VolumeNumber,long directoryID);
void SqueakTerminate();
void ExitCleanup();
int calculateStartLocationForImage();
extern int dropInit(void);
Boolean RunningOnCarbonX(void);

OSStatus GetApplicationDirectory(short *vRefNum, long *dirID);
pascal	OSErr	GetFullPath(short vRefNum,
							long dirID,
							ConstStr255Param name,
							short *fullPathLength,
							Handle *fullPath);
pascal	OSErr	FSpGetFullPath(const FSSpec *spec,
							   short *fullPathLength,
							   Handle *fullPath);
pascal OSErr FSpLocationFromFullPath(short fullPathLength,
									 const void *fullPath,
									 FSSpec *spec);
pascal	OSErr	FSMakeFSSpecCompat(short vRefNum,
								   long dirID,
								   ConstStr255Param fileName,
								   FSSpec *spec);

/* event capture */
sqInputEvent *nextEventPut(void);

int recordKeystroke(EventRecord *theEvent);
int recordModifierButtons(EventRecord *theEvent);
int recordMouseDown(EventRecord *theEvent);
int recordMouseEvent(EventRecord *theEvent, int theButtonState);
int recordDragDropEvent(EventRecord *theEvent, int theButtonState, int numberOfItems, int dragType);
int recordKeyboardEvent(EventRecord *theEvent, int keyType);
int MouseModifierState(EventRecord *theEvent);
WindowPtr getSTWindow(void);
int setMessageHook(eventMessageHook theHook);
int setPostMessageHook(eventMessageHook theHook);
void PowerMgrCheck(void);


/*** Apple Event Handlers ***/
static pascal OSErr HandleOpenAppEvent(const AEDescList *aevt,  AEDescList *reply, long refCon);
static pascal OSErr HandleOpenDocEvent(const AEDescList *aevt,  AEDescList *reply, long refCon);
static pascal OSErr HandlePrintDocEvent(const AEDescList *aevt, AEDescList *reply, long refCon);
static pascal OSErr HandleQuitAppEvent(const AEDescList *aevt,  AEDescList *reply, long refCon);

/*** Apple Event Handling ***/

void InstallAppleEventHandlers() {
	OSErr	err;
	long	result;

	shortImageName[0] = 0;
	err = Gestalt(gestaltAppleEventsAttr, &result);
	if (err == noErr) {
		AEInstallEventHandler(kCoreEventClass, kAEOpenApplication, NewAEEventHandlerUPP(HandleOpenAppEvent),  0, false);
		AEInstallEventHandler(kCoreEventClass, kAEOpenDocuments,   NewAEEventHandlerUPP(HandleOpenDocEvent),  0, false);
		AEInstallEventHandler(kCoreEventClass, kAEPrintDocuments,  NewAEEventHandlerUPP(HandlePrintDocEvent), 0, false);
		AEInstallEventHandler(kCoreEventClass, kAEQuitApplication, NewAEEventHandlerUPP(HandleQuitAppEvent),  0, false);
	}
}

pascal OSErr HandleOpenAppEvent(const AEDescList *aevt,  AEDescList *reply, long refCon) {
	/* User double-clicked application; look for "squeak.image" in same directory */
    int                 checkValueForEmbeddedImage;
    OSErr               err;
	FSSpec		        fileSpec;
	Str32                name; 
	
/* record path to VM''s home folder */
	short vRefNum;
	long dirID;

	// Get the Volume ref and Directory id of the Application''s directory.
    err = GetApplicationDirectory(&vRefNum, &dirID);
    if (err != noErr) return err;

	// Convert that to a full path string.
	PathToWorkingDir(vmPath, VMPATH_SIZE, vRefNum, dirID);

	checkValueForEmbeddedImage = calculateStartLocationForImage();
	if (checkValueForEmbeddedImage == 0) {
	    /* use default image name in same directory as the VM */
	    strcpy(shortImageName, "squeak.image");
	    return noErr;
	}

	if (err != noErr) {
		strcpy(shortImageName, "squeak.image");
	    return noErr;
	}
	
	CopyPascalStringToC(name,shortImageName);
	StoreFullPathForLocalNameInto(shortImageName, imageName, IMAGE_NAME_SIZE, vRefNum, dirID);

    return noErr;
}

pascal OSErr HandleOpenDocEvent(const AEDescList *aevt, AEDescList *reply, long refCon) {
	/* User double-clicked an image file. Record the path to the VM''s directory,
	   then set the default directory to the folder containing the image and
	   record the image name. Fail if mullitple image files were selected. */

	OSErr		err;
	AEDesc		fileList = {''NULL'', NULL};
	long		numFiles, size;
	DescType	type;
	AEKeyword	keyword;
	FSSpec		fileSpec;
	WDPBRec		pb;
	FInfo		finderInformation;
	char 		tempShortName[SHORTIMAGE_NAME_SIZE + 1];	
	short vRefNum;
	long dirID;
	
	reply; refCon;  /* reference args to avoid compiler warnings */

	/* record path to VM''s home folder */
    err = GetApplicationDirectory(&vRefNum, &dirID);
    if (err != noErr) return err;
    
	PathToWorkingDir(vmPath, VMPATH_SIZE, vRefNum, dirID);
	
	/* copy document list */
	err = AEGetKeyDesc(aevt, keyDirectObject, typeAEList, &fileList);
	if (err) return errAEEventNotHandled;;

	/* count list elements */
	err = AECountItems( &fileList, &numFiles);
	if (err) goto done;
	
	if (shortImageName[0] != 0) {
#ifdef IHAVENOHEAD
		/* get image name */
		err = AEGetNthPtr(&fileList, 1, typeFSS,
						  &keyword, &type, (Ptr) &fileSpec, sizeof(fileSpec), &size);
		if (err) goto done;
		
		err = FSpGetFInfo(&fileSpec,&finderInformation);
		if (err) goto done;
			
		CopyPascalStringToC(fileSpec.name,tempShortName);

		if (finderInformation.fdType == ''SOBJ'') {
			StoreFullPathForLocalNameInto(tempShortName, documentName, DOCUMENT_NAME_SIZE,fileSpec.vRefNum,fileSpec.parID);
		}
#endif
		goto done;
	}

	/* get image name */
	err = AEGetNthPtr(&fileList, 1, typeFSS,
					  &keyword, &type, (Ptr) &fileSpec, sizeof(fileSpec), &size);
	if (err) goto done;
	
	err = FSpGetFInfo(&fileSpec,&finderInformation);
	if (err) goto done;
		
	CopyPascalStringToC(fileSpec.name,shortImageName);

	if (!(IsImageName(shortImageName) || finderInformation.fdType == ''STim'') || finderInformation.fdType == ''STch'') {
		/* record the document name, but run the default image in VM directory */
		if (finderInformation.fdType == ''SOBJ'')
			StoreFullPathForLocalNameInto(shortImageName, documentName, DOCUMENT_NAME_SIZE,fileSpec.vRefNum,fileSpec.parID);

		strcpy(shortImageName, "squeak.image");
		StoreFullPathForLocalNameInto(shortImageName, imageName, IMAGE_NAME_SIZE, vRefNum, dirID);
	}
	/* make the image or document directory the working directory */
	pb.ioNamePtr = NULL;
	pb.ioVRefNum = fileSpec.vRefNum;
	pb.ioWDDirID = fileSpec.parID;
	PBHSetVolSync(&pb);

done:
	AEDisposeDesc(&fileList);
	return err;
}

pascal OSErr HandlePrintDocEvent(const AEDescList *aevt,  AEDescList *reply, long refCon) {
	aevt; reply; refCon;  /* reference args to avoid compiler warnings */
	return errAEEventNotHandled;
}

pascal OSErr HandleQuitAppEvent(const AEDescList *aevt,  AEDescList *reply, long refCon) {
	aevt; reply; refCon;  /* reference args to avoid compiler warnings */
	return errAEEventNotHandled;
}

/*** VM Home Directory Path ***/

int vmPathSize(void) {
	return strlen(vmPath);
}

int vmPathGetLength(int sqVMPathIndex, int length) {
	char *stVMPath = (char *) sqVMPathIndex;
	int count, i;

	count = strlen(vmPath);
	count = (length < count) ? length : count;

	/* copy the file name into the Squeak string */
	for (i = 0; i < count; i++) {
		stVMPath[i] = vmPath[i];
	}
	return count;
}

/*** Mac-related Functions ***/

void AdjustMenus(void) {
	WindowRef		wp;
	int				isDeskAccessory;

	wp = FrontWindow();
	if (wp != NULL) {
		isDeskAccessory = GetWindowKind(wp) < 0;
	} else {
		isDeskAccessory = false;
	}

	if (isDeskAccessory) {
		/* Enable items in the Edit menu */
		EnableMenuItemCarbon(editMenu, 1);
		EnableMenuItemCarbon(editMenu, 3);
		EnableMenuItemCarbon(editMenu, 4);
		EnableMenuItemCarbon(editMenu, 5);
		EnableMenuItemCarbon(editMenu, 6);
	} else {
		/* Disable items in the Edit menu */
		DisableMenuItemCarbon(editMenu, 1);
		DisableMenuItemCarbon(editMenu, 3);
		DisableMenuItemCarbon(editMenu, 4);
		DisableMenuItemCarbon(editMenu, 5);
		DisableMenuItemCarbon(editMenu, 6);
	}
}

int HandleEvents(void) {
	EventRecord		theEvent;
	static EventRecord oldEvent;
	int				ok;
	Rect    bounds;

	ok = WaitNextEvent(everyEvent, &theEvent,0,null);
	if((messageHook) && (messageHook(&theEvent))) {
        return ok;
    }
	if (ok) {
		switch (theEvent.what) {
			case mouseDown:
				HandleMouseDown(&theEvent);
				if(postMessageHook) postMessageHook(&theEvent);
				return false;
			break;

			case mouseUp:
				if(inputSemaphoreIndex) {
					recordMouseEvent(&theEvent,MouseModifierState(&theEvent));
    				if(postMessageHook) postMessageHook(&theEvent);
					return false;
				}
				recordModifierButtons(&theEvent);
				if(postMessageHook) postMessageHook(&theEvent);
				return false;
			break;

			case keyDown:
			case autoKey:
				if ((theEvent.modifiers & cmdKey) != 0) {
					AdjustMenus();
					HandleMenu(MenuKey(theEvent.message & charCodeMask));
				}
				if(inputSemaphoreIndex) {
					recordKeyboardEvent(&theEvent,EventKeyDown);
					break;
				}
				recordModifierButtons(&theEvent);
				recordKeystroke(&theEvent);
			break;
			
			case keyUp:
				if(inputSemaphoreIndex) {
					recordKeyboardEvent(&theEvent,EventKeyUp);
				}
			break;

#ifndef IHAVENOHEAD
			case updateEvt:
				BeginUpdate(stWindow);
				fullDisplayUpdate();  /* this makes VM call ioShowDisplay */
				EndUpdate(stWindow);
			break;

			case activateEvt:
				if (theEvent.modifiers & activeFlag) {
					windowActive = true;
				} else {
					GetMouse(&savedMousePosition);
					windowActive = false;
				}
				GetPortBounds(GetWindowPort(stWindow),&bounds);
				InvalWindowRect(stWindow,&bounds);
			break;
#endif

			case kHighLevelEvent:
				AEProcessAppleEvent(&theEvent);
			break;
			
			case osEvt: 
				if (((theEvent.message>>24)& 0xFF) == suspendResumeMessage) {
				
					//JMM July 4th 2000
					//Fix for menu bar tabbing, thanks to Javier Diaz-Reinoso for pointing this out
					//
					if (fullScreenFlag) {
						if ((theEvent.message & resumeFlag) == 0) {
							MenuBarRestore();
						}
						else {
							MenuBarHide();
						}
					}
				}
				break;
		}
	}
	else {
		if(inputSemaphoreIndex && windowActive && 
		    !((oldEvent.what == theEvent.what) && 
 		    (oldEvent.message == theEvent.message) &&
 		    ((oldEvent.where.v == theEvent.where.v) && (oldEvent.where.h == theEvent.where.h)) &&
 		    (oldEvent.modifiers == theEvent.modifiers))) {
    		oldEvent = theEvent; //JMM Nov 11th 2000 bug fix 
			recordMouseEvent(&theEvent,MouseModifierState(&theEvent));
 		}
 		else
		 oldEvent = theEvent;
	}
	if(postMessageHook) postMessageHook(&theEvent); 
	return ok;
}

void HandleMenu(int mSelect) {
	int			menuID, menuItem;
	Str255		name;
	GrafPtr		savePort;

	menuID = HiWord(mSelect);
	menuItem = LoWord(mSelect);
	switch (menuID) {
		case appleID:
			GetPort(&savePort);
			GetMenuItemText(appleMenu, menuItem, name);
#if !TARGET_API_MAC_CARBON
			OpenDeskAcc(name);
#endif 
			SetPort(savePort);
		break;

		case fileID:
			if (menuItem == quitItem) {
				ioExit();
			}
		break;

		case editID:
#if !TARGET_API_MAC_CARBON
			if (!SystemEdit(menuItem - 1)) {
				SysBeep(5);
			}
#endif
		break;
	}
}

void HandleMouseDown(EventRecord *theEvent) {
    BitMap      bmap;
	WindowPtr	theWindow;
	Rect		growLimits = { 20, 20, 4000, 4000 };
	int			windowCode, newSize;

	windowCode = FindWindow(theEvent->where, &theWindow);
	switch (windowCode) {
		case inSysWindow:
#if !TARGET_API_MAC_CARBON
			SystemClick(theEvent, theWindow);
#endif
		break;

		case inMenuBar:
			AdjustMenus();
			HandleMenu(MenuSelect(theEvent->where));
		break;

#ifndef IHAVENOHEAD
		case inDrag:

			GetQDGlobalsScreenBits(&bmap);
			if (theWindow == stWindow) {
				DragWindow(stWindow, theEvent->where, &bmap.bounds);
			}
		break;

		case inGrow:
			if (theWindow == stWindow) {
				newSize = GrowWindow(stWindow, theEvent->where, &growLimits);
				if (newSize != 0) {
					SizeWindow(stWindow, LoWord(newSize), HiWord(newSize), true);
				}
			}
		break;

		case inContent:
			if (theWindow == stWindow) {
				if (theWindow != FrontWindow()) {
					SelectWindow(stWindow);
				}
				if(inputSemaphoreIndex) {
					recordMouseEvent(theEvent,MouseModifierState(theEvent));
					break;
				}
				recordMouseDown(theEvent);
			}
		break;

		case inGoAway:
			if ((theWindow == stWindow) &&
				(TrackGoAway(stWindow, theEvent->where))) {
					/* HideWindow(stWindow); noop for now */
			}
		break;
#endif
	}
}


#if TARGET_API_MAC_CARBON
void InitMacintosh(void) {
	FlushEvents(everyEvent, 0);
	InitCursor();
}

void MenuBarHide(void) {
 	if (menuBarRegion != nil) return;  /* saved state, so menu bar is already hidden */
    menuBarRegion = (RgnHandle) 1;
    HideMenuBar();
}
void MenuBarRestore(void) {
	if (menuBarRegion == nil) return;  /* no saved state, so menu bar is not hidden */
    ShowMenuBar();
    menuBarRegion = nil;
}

/*** Clipboard Support (text only for now) ***/

void SetUpClipboard(void) {
}

void FreeClipboard(void) {
}

int clipboardReadIntoAt(int count, int byteArrayIndex, int startIndex) {
	long clipSize, charsToMove;
	ScrapRef scrap;
	OSStatus err;

    err = GetCurrentScrap (&scrap);
    if (err != noErr) return 0;       
	clipSize = clipboardSize();
 	charsToMove = (count < clipSize) ? count : clipSize;
    err = GetScrapFlavorData(scrap,kScrapFlavorTypeText,(long *) &charsToMove,(char *) byteArrayIndex + startIndex);
    if (err != noErr) { 
        FreeClipboard();
        return 0;       
    }
	return charsToMove;
}

int clipboardSize(void) {
	long count;
	ScrapRef scrap;
	OSStatus err;

    err = GetCurrentScrap (&scrap);
    if (err != noErr) return 0;       
    err = GetScrapFlavorSize (scrap, kScrapFlavorTypeText, &count); 
	if (err != noErr) {
		return 0;
	} else {
		return count;
	}
}

int clipboardWriteFromAt(int count, int byteArrayIndex, int startIndex) {
	ScrapRef scrap;
	OSErr err;
	err = ClearCurrentScrap();
    err = GetCurrentScrap (&scrap);
	err = PutScrapFlavor ( scrap, kScrapFlavorTypeText, kScrapFlavorMaskNone , count,  (const void *) (byteArrayIndex + startIndex));
}

#else 
void InitMacintosh(void) {
	MaxApplZone();
	InitGraf(&qd.thePort);
	InitFonts();
	FlushEvents(everyEvent, 0);
	InitWindows();
	InitMenus();
	TEInit();
	InitDialogs(NULL);
	InitCursor();
}

void MenuBarHide(void) {
  /* Remove the menu bar, saving its old state. */
  /* Many thanks to John McIntosh for this code! */
	Rect screenRect, mBarRect;

	if (menuBarRegion != nil) return;  /* saved state, so menu bar is already hidden */
	screenRect = (**GetMainDevice()).gdRect;
	menuBarHeight = GetMBarHeight();
	SetRect(&mBarRect, screenRect.left, screenRect.top, screenRect.right, screenRect.top + menuBarHeight);
	menuBarRegion = NewRgn();
	if (menuBarRegion != nil) {
		LMSetMBarHeight(0);
		RectRgn(menuBarRegion, &mBarRect);
		UnionRgn(GetGrayRgn(), menuBarRegion, GetGrayRgn());
	}
}

void MenuBarRestore(void) {
  /* Restore the menu bar from its saved state. Do nothing if it isn''t hidden. */
  /* Many thanks to John McIntosh for this code! */
 
 	WindowPtr win;
 	
	if (menuBarRegion == nil) return;  /* no saved state, so menu bar is not hidden */
	DiffRgn(GetGrayRgn(), menuBarRegion, GetGrayRgn());
	LMSetMBarHeight(menuBarHeight);
	
	win = FrontWindow();
	if (win) {
		CalcVis(win);
		CalcVisBehind(win,menuBarRegion);
	}
	HiliteMenu(0);
	DisposeRgn(menuBarRegion);
	
	menuBarRegion = nil;
	DrawMenuBar();
}

/*** Clipboard Support (text only for now) ***/
Handle			clipboardBuffer = nil;

void SetUpClipboard(void) {
	/* allocate clipboard in the system heap to support really big copy/paste */
	THz oldZone;

	oldZone = GetZone();
	SetZone(SystemZone());
	clipboardBuffer = NewHandle(0);
	SetZone(oldZone);
}

void FreeClipboard(void) {
	if (clipboardBuffer != nil) {
		DisposeHandle(clipboardBuffer);
		clipboardBuffer = nil;
	}
}

int clipboardReadIntoAt(int count, int byteArrayIndex, int startIndex) {
	long clipSize, charsToMove;
	char *srcPtr, *dstPtr, *end;

	clipSize = clipboardSize();
	charsToMove = (count < clipSize) ? count : clipSize;
    //JMM locking
    HLock(clipboardBuffer); 
	srcPtr = (char *) *clipboardBuffer;
	dstPtr = (char *) byteArrayIndex + startIndex;
	end = srcPtr + charsToMove;
	while (srcPtr < end) {
		*dstPtr++ = *srcPtr++;
	}
    HUnlock(clipboardBuffer); 
	return charsToMove;
}

int clipboardSize(void) {
	long count, offset;

	count = GetScrap(clipboardBuffer, ''TEXT'', &offset);
	if (count < 0) {
		return 0;
	} else {
		return count;
	}
}

int clipboardWriteFromAt(int count, int byteArrayIndex, int startIndex) {
	ZeroScrap();
	PutScrap(count, ''TEXT'', (char *) (byteArrayIndex + startIndex));
}

#endif

void SetUpMenus(void) {
	long decideOnQuitMenu;
	
	InsertMenu(appleMenu = NewMenu(appleID, "\p\024"), 0);
	InsertMenu(fileMenu  = NewMenu(fileID,  "\pFile"), 0);
	InsertMenu(editMenu  = NewMenu(editID,  "\pEdit"), 0);
	DrawMenuBar();
#if TARGET_API_MAC_CARBON
    Gestalt( gestaltMenuMgrAttr, &decideOnQuitMenu);
    if (!(decideOnQuitMenu & gestaltMenuMgrAquaLayoutMask))	
        AppendMenu(fileMenu, "\pQuit");
#else
	AppendResMenu(appleMenu, ''DRVR'');
    AppendMenu(fileMenu, "\pQuit");
#endif
 	AppendMenu(editMenu, "\pUndo/Z;(-;Cut/X;Copy/C;Paste/V;Clear");
}

void SetColorEntry(int index, int red, int green, int blue) {
	(*stColorTable)->ctTable[index].value = index;
	(*stColorTable)->ctTable[index].rgb.red = red;
	(*stColorTable)->ctTable[index].rgb.green = green;
	(*stColorTable)->ctTable[index].rgb.blue = blue;
}

void FreePixmap(void) {
	if (stPixMap != nil) {
		DisposePixMap(stPixMap);
		stPixMap = nil;
	}

	if (stColorTable != nil) {
		DisposeHandle((void *) stColorTable);
		stColorTable = nil;
	}
}

void SetUpPixmap(void) {
	int i, r, g, b;

	stColorTable = (CTabHandle) NewHandle(sizeof(ColorTable) + (256 * sizeof(ColorSpec)));
	(*stColorTable)->ctSeed = GetCTSeed();
	(*stColorTable)->ctFlags = 0;
	(*stColorTable)->ctSize = 255;

	/* 1-bit colors (monochrome) */
	SetColorEntry(0, 65535, 65535, 65535);	/* white or transparent */
	SetColorEntry(1,     0,     0,     0);	/* black */

	/* additional colors for 2-bit color */
	SetColorEntry(2, 65535, 65535, 65535);	/* opaque white */
	SetColorEntry(3, 32768, 32768, 32768);	/* 1/2 gray */

	/* additional colors for 4-bit color */
	SetColorEntry( 4, 65535,     0,     0);	/* red */
	SetColorEntry( 5,     0, 65535,     0);	/* green */
	SetColorEntry( 6,     0,     0, 65535);	/* blue */
	SetColorEntry( 7,     0, 65535, 65535);	/* cyan */
	SetColorEntry( 8, 65535, 65535,     0);	/* yellow */
	SetColorEntry( 9, 65535,     0, 65535);	/* magenta */
	SetColorEntry(10,  8192,  8192,  8192);	/* 1/8 gray */
	SetColorEntry(11, 16384, 16384, 16384);	/* 2/8 gray */
	SetColorEntry(12, 24576, 24576, 24576);	/* 3/8 gray */
	SetColorEntry(13, 40959, 40959, 40959);	/* 5/8 gray */
	SetColorEntry(14, 49151, 49151, 49151);	/* 6/8 gray */
	SetColorEntry(15, 57343, 57343, 57343);	/* 7/8 gray */

	/* additional colors for 8-bit color */
	/* 24 more shades of gray (does not repeat 1/8th increments) */
	SetColorEntry(16,  2048,  2048,  2048);	/*  1/32 gray */
	SetColorEntry(17,  4096,  4096,  4096);	/*  2/32 gray */
	SetColorEntry(18,  6144,  6144,  6144);	/*  3/32 gray */
	SetColorEntry(19, 10240, 10240, 10240);	/*  5/32 gray */
	SetColorEntry(20, 12288, 12288, 12288);	/*  6/32 gray */
	SetColorEntry(21, 14336, 14336, 14336);	/*  7/32 gray */
	SetColorEntry(22, 18432, 18432, 18432);	/*  9/32 gray */
	SetColorEntry(23, 20480, 20480, 20480);	/* 10/32 gray */
	SetColorEntry(24, 22528, 22528, 22528);	/* 11/32 gray */
	SetColorEntry(25, 26624, 26624, 26624);	/* 13/32 gray */
	SetColorEntry(26, 28672, 28672, 28672);	/* 14/32 gray */
	SetColorEntry(27, 30720, 30720, 30720);	/* 15/32 gray */
	SetColorEntry(28, 34815, 34815, 34815);	/* 17/32 gray */
	SetColorEntry(29, 36863, 36863, 36863);	/* 18/32 gray */
	SetColorEntry(30, 38911, 38911, 38911);	/* 19/32 gray */
	SetColorEntry(31, 43007, 43007, 43007);	/* 21/32 gray */
	SetColorEntry(32, 45055, 45055, 45055);	/* 22/32 gray */
	SetColorEntry(33, 47103, 47103, 47103);	/* 23/32 gray */
	SetColorEntry(34, 51199, 51199, 51199);	/* 25/32 gray */
	SetColorEntry(35, 53247, 53247, 53247);	/* 26/32 gray */
	SetColorEntry(36, 55295, 55295, 55295);	/* 27/32 gray */
	SetColorEntry(37, 59391, 59391, 59391);	/* 29/32 gray */
	SetColorEntry(38, 61439, 61439, 61439);	/* 30/32 gray */
	SetColorEntry(39, 63487, 63487, 63487);	/* 31/32 gray */

	/* The remainder of color table defines a color cube with six steps
	   for each primary color. Note that the corners of this cube repeat
	   previous colors, but simplifies the mapping between RGB colors and
	   color map indices. This color cube spans indices 40 through 255.
	*/
	for (r = 0; r < 6; r++) {
		for (g = 0; g < 6; g++) {
			for (b = 0; b < 6; b++) {
				i = 40 + ((36 * r) + (6 * b) + g);
				if (i > 255) error("index out of range in color table compuation");
				SetColorEntry(i, (r * 65535) / 5, (g * 65535) / 5, (b * 65535) / 5);
			}
		}
	}

	stPixMap = NewPixMap();
	(*stPixMap)->pixelType = 0; /* chunky */
	(*stPixMap)->cmpCount = 1;
	(*stPixMap)->pmTable = stColorTable;
}

void SetUpWindow(void) {
	Rect windowBounds = {44, 8, 300, 500};

#ifndef IHAVENOHEAD
	stWindow = NewCWindow(
		0L, &windowBounds,
		"\p Welcome to Squeak!  Reading Squeak image file... ",
		true, documentProc, (WindowPtr) -1L, false, 0);
#endif
}

void SetWindowTitle(char *title) {
    Str255 tempTitle;
	CopyCStringToPascal(title,tempTitle);
#ifndef IHAVENOHEAD
	SetWTitle(stWindow, tempTitle);
#endif
}

/*** Event Recording Functions ***/

int recordKeystroke(EventRecord *theEvent) {
	int asciiChar, modifierBits, keystate;

	/* keystate: low byte is the ascii character; next 4 bits are modifier bits */
	asciiChar = theEvent->message & charCodeMask;
	modifierBits = modifierMap[(theEvent->modifiers >> 8) & 0x1F];
	if ((modifierBits & 0x9) == 0x9) {  /* command and shift */
		if ((asciiChar >= 97) && (asciiChar <= 122)) {
			/* convert ascii code of command-shift-letter to upper case */
			asciiChar = asciiChar - 32;
		}
	}

	keystate = (modifierBits << 8) | asciiChar;
	if (keystate == interruptKeycode) {
		/* Note: interrupt key is "meta"; it not reported as a keystroke */
		interruptPending = true;
		interruptCheckCounter = 0;
	} else {
		keyBuf[keyBufPut] = keystate;
		keyBufPut = (keyBufPut + 1) % KEYBUF_SIZE;
		if (keyBufGet == keyBufPut) {
			/* buffer overflow; drop the last character */
			keyBufGet = (keyBufGet + 1) % KEYBUF_SIZE;
			keyBufOverflows++;
		}
	}
}

int recordMouseDown(EventRecord *theEvent) {

	/* button state: low three bits are mouse buttons; next 4 bits are modifier bits */
	buttonState = MouseModifierState(theEvent);
	cachedButtonState = cachedButtonState | buttonState;
}

int MouseModifierState(EventRecord *theEvent) {
	int stButtons;

	stButtons = 0;
	if ((theEvent->modifiers & btnState) == false) {  /* is false if button is down */
		stButtons = 4;		/* red button by default */
		if ((theEvent->modifiers & optionKey) != 0) {
			stButtons = 2;	/* yellow button if option down */
		}
		if ((theEvent->modifiers & cmdKey) != 0) {
			stButtons = 1;	/* blue button if command down */
		}
	} 

	/* button state: low three bits are mouse buttons; next 4 bits are modifier bits */
	return ((modifierMap[(theEvent->modifiers >> 8) & 0x1F] << 3) |
		(stButtons & 0x7));
}

int recordModifierButtons(EventRecord *theEvent) {
	int stButtons = 0;

	if ((theEvent->modifiers & btnState) == false) {
		stButtons = buttonState & 0x7;
	} else {
		stButtons = 0;
	}
	/* button state: low three bits are mouse buttons; next 4 bits are modifier bits */
	buttonState =
		(modifierMap[(theEvent->modifiers >> 8) & 0x1F] << 3) |
		(stButtons & 0x7);
}

int recordMouseEvent(EventRecord *theEvent, int theButtonState) {
	sqMouseEvent *evt;
	
	evt = (sqMouseEvent*) nextEventPut();

	/* first the basics */
	evt->type = EventTypeMouse;
	evt->timeStamp = ioMSecs(); 
	GlobalToLocal((Point *) &theEvent->where);
	evt->x = theEvent->where.h;
	evt->y = theEvent->where.v;
	/* then the buttons */
	evt->buttons = theButtonState & 0x07;
	/* then the modifiers */
	evt->modifiers = theButtonState >> 3;
	/* clean up reserved */
	evt->reserved1 = 0;
	evt->reserved2 = 0;
//	signalSemaphoreWithIndex(inputSemaphoreIndex);
	return 1;
}

int recordDragDropEvent(EventRecord *theEvent, int theButtonState, int numberOfItems, int dragType) {
	sqDragDropFilesEvent *evt;
	
	evt = (sqDragDropFilesEvent*) nextEventPut();

	/* first the basics */
	evt->type = EventTypeDragDropFiles;
	evt->timeStamp = ioMSecs(); 
	GlobalToLocal((Point *) &theEvent->where);
	evt->x = theEvent->where.h;
	evt->y = theEvent->where.v;
	evt->numFiles = numberOfItems;
	evt->dragType = dragType;
	
	/* then the modifiers */
	evt->modifiers = theButtonState >> 3;
	/* clean up reserved */
	evt->reserved1 = 0;
//	signalSemaphoreWithIndex(inputSemaphoreIndex);
	return 1;
}

int recordKeyboardEvent(EventRecord *theEvent, int keyType) {
	int stButtons = 0;
	int asciiChar, modifierBits;
	sqKeyboardEvent *evt, *extra;

	evt = (sqKeyboardEvent*) nextEventPut();

	/* keystate: low byte is the ascii character; next 4 bits are modifier bits */
	asciiChar = theEvent->message & charCodeMask;
	modifierBits = MouseModifierState(theEvent); //Capture mouse/option states
	if (((modifierBits >> 3) & 0x9) == 0x9) {  /* command and shift */
		if ((asciiChar >= 97) && (asciiChar <= 122)) {
			/* convert ascii code of command-shift-letter to upper case */
			asciiChar = asciiChar - 32;
		}
	}

	/* first the basics */
	evt->type = EventTypeKeyboard;
	evt->timeStamp = ioMSecs();
	/* now the key code */
	/* press code must differentiate */
	evt->charCode = (theEvent->message & keyCodeMask) >> 8;
	evt->pressCode = keyType;
	evt->modifiers = modifierBits >> 3;
	/* clean up reserved */
	evt->reserved1 = 0;
	evt->reserved2 = 0;
	/* generate extra character event */
	if (keyType == EventKeyDown) {
		extra = (sqKeyboardEvent*)nextEventPut();
		*extra = *evt;
		extra->charCode = asciiChar;
		extra->pressCode = EventKeyChar;
	}
//	signalSemaphoreWithIndex(inputSemaphoreIndex);
	return 1;
}

static sqInputEvent *nextEventPut(void) {
	sqInputEvent *evt;
	evt = eventBuffer + eventBufferPut;
	eventBufferPut = (eventBufferPut + 1) % MAX_EVENT_BUFFER;
	if (eventBufferGet == eventBufferPut) {
		/* buffer overflow; drop the last event */
		eventBufferGet = (eventBufferGet + 1) % MAX_EVENT_BUFFER;
	}
	return evt;
}

int ioSetInputSemaphore(int semaIndex) {
	inputSemaphoreIndex = semaIndex;
	return 1;
}

int ioGetNextEvent(sqInputEvent *evt) {
	if (eventBufferGet == eventBufferPut) {
		ioProcessEvents();
	}
	if (eventBufferGet == eventBufferPut) 
		return false;

	*evt = eventBuffer[eventBufferGet];
	eventBufferGet = (eventBufferGet+1) % MAX_EVENT_BUFFER;
	return true;
}


/*** Mac Specific External Primitive Support ***/

/* ioLoadModule:
	Load a module from disk.
	WARNING: this always loads a *new* module. Don''t even attempt to find a loaded one.
	WARNING: never primitiveFail() within, just return 0
*/
int ioLoadModule(char *pluginName) {
	char pluginDirPath[1000];
	CFragConnectionID libHandle;
	Ptr mainAddr;
	Str255 errorMsg,tempPluginName;
	OSErr err;
    
    	/* first, look in the "<Squeak VM directory>Plugins" directory for the library */
	strcpy(pluginDirPath, vmPath);
	
#ifdef PLUGIN
	strcat(pluginDirPath, ":Plugins");
#else
	strcat(pluginDirPath, "Plugins");
#endif 	
    
    libHandle = LoadLibViaPath(pluginName, pluginDirPath);
	if (libHandle != nil) return (int) libHandle;

#ifndef PLUGIN
	/* second, look directly in Squeak VM directory for the library */
	libHandle = LoadLibViaPath(pluginName, vmPath);
	if (libHandle != nil) return (int) libHandle;
    
    /* Lastly look for it as a shared import library */
    
    CopyCStringToPascal(pluginName,tempPluginName);
    err = GetSharedLibrary(tempPluginName, kAnyCFragArch, kLoadCFrag, &libHandle, &mainAddr, errorMsg);
	if (err == noErr) 
	    err = GetSharedLibrary(tempPluginName, kAnyCFragArch, kFindCFrag, &libHandle, &mainAddr, errorMsg);
	if (libHandle != nil) return (int) libHandle;
#endif
    
	return nil;
}

/* ioFindExternalFunctionIn:
	Find the function with the given name in the moduleHandle.
	WARNING: never primitiveFail() within, just return 0.
*/
int ioFindExternalFunctionIn(char *lookupName, int moduleHandle) {
	CFragSymbolClass ignored;
	Ptr functionPtr = 0;
	OSErr err;
    Str255 tempLookupName;
    
	if (!moduleHandle) return 0;

	/* get the address of the desired primitive function */
	CopyCStringToPascal(lookupName,tempLookupName);
	err = FindSymbol(
		(CFragConnectionID) moduleHandle, (unsigned char *) tempLookupName,
		&functionPtr, &ignored);
	if (err) return 0;

	return (int) functionPtr;
}

/* ioFreeModule:
	Free the module with the associated handle.
	WARNING: never primitiveFail() within, just return 0.
*/
int ioFreeModule(int moduleHandle) {
	CFragConnectionID libHandle;
	OSErr err;

	if (!moduleHandle) return 0;
	libHandle = (CFragConnectionID) moduleHandle;
	err = CloseConnection(&libHandle);
	return 0;
}

CFragConnectionID LoadLibViaPath(char *libName, char *pluginDirPath) {
	short 				vRefNum;
	long				ignore;
	CInfoPBRec 			pb;
	FSSpec				fileSpec;
	Str255				problemLibName,fileSpecName,tempPlugindirPath;
    Ptr					junk;
	CFragConnectionID	libHandle = 0;
	OSErr				err = noErr;

	/* get the default volume */
	HGetVol( nil, &vRefNum, &ignore);

	/* get the directory ID for the given path */
	CopyCStringToPascal(pluginDirPath,tempPlugindirPath);
	pb.hFileInfo.ioNamePtr = tempPlugindirPath;
	pb.hFileInfo.ioVRefNum = 0;  /* use the default volume */
	pb.hFileInfo.ioFDirIndex = 0;
	pb.hFileInfo.ioDirID = 0;
	err = PBGetCatInfoSync(&pb);
	if (err) return nil; /* bad plugin directory path */

	/* make a file spec for the given file name in the plugin directory */
	CopyCStringToPascal(libName,fileSpecName);
	FSMakeFSSpec(vRefNum,pb.hFileInfo.ioDirID,fileSpecName,&fileSpec);

	err = GetDiskFragment(
		&fileSpec, 0, kCFragGoesToEOF, nil, kLoadCFrag, &libHandle, &junk, problemLibName);
	if (err) return nil;
	return libHandle;
}
/*** I/O Primitives ***/

int ioBeep(void) {
	SysBeep(1000);
}

#ifndef PLUGIN
int ioExit(void) {
	ioShutdownAllModules();
	MenuBarRestore();
	ExitToShell();
}
#endif

int ioForceDisplayUpdate(void) {
	/* do nothing on a Mac */
}

int ioFormPrint(int bitsAddr, int width, int height, int depth, double hScale, double vScale, int landscapeFlag) {
	/* experimental: print a form with the given bitmap, width, height, and depth at
	   the given horizontal and vertical scales in the given orientation */
	printf("ioFormPrint width %d height %d depth %d hScale %f vScale %f landscapeFlag %d\n",
		width, height, depth, hScale, vScale, landscapeFlag);
	bitsAddr;
	return true;
}

int ioGetButtonState(void) {
	ioProcessEvents();  /* process all pending events */
	if ((cachedButtonState & 0x7) != 0) {
		int result = cachedButtonState;
		cachedButtonState = 0;  /* clear cached button state */
		return result;
	}
	cachedButtonState = 0;  /* clear cached button state */
	return buttonState;
}

int ioGetKeystroke(void) {
	int keystate;

	ioProcessEvents();  /* process all pending events */
	if (keyBufGet == keyBufPut) {
		return -1;  /* keystroke buffer is empty */
	} else {
		keystate = keyBuf[keyBufGet];
		keyBufGet = (keyBufGet + 1) % KEYBUF_SIZE;
		/* set modifer bits in buttonState to reflect the last keystroke fetched */
		buttonState = ((keystate >> 5) & 0xF8) | (buttonState & 0x7);
	}
	return keystate;
}

int ioHasDisplayDepth(int depth) {
	/* Return true if this platform supports the given color display depth. */

	switch (depth) {
	case 1:
	case 2:
	case 4:
	case 8:
	case 16:
	case 32:
		return true;
	}
	return false;
}


int ioMicroMSecsExpensive(void);

int ioMicroMSecsExpensive(void) {
	UnsignedWide microTicks;
	Microseconds(&microTicks);
	return (microTicks.lo / 1000) + (microTicks.hi * 4294967);
}

#if TARGET_CPU_PPC
int ioMicroMSecs(void) {
	/* Note: This function and ioMSecs() both return a time in milliseconds. The difference
	   is that ioMicroMSecs() is called only when precise millisecond resolution is essential,
	   and thus it can use a more expensive timer than ioMSecs, which is called frequently.
	   However, later VM optimizations reduced the frequency of calls to ioMSecs to the point
	   where clock performance became less critical, and we also started to want millisecond-
	   resolution timers for real time applications such as music. */
	
	register long check;
	
	if((Ptr)OTElapsedMilliseconds!=(Ptr)kUnresolvedCFragSymbolAddress){
    	check = OTElapsedMilliseconds(&timeStart);
    	if (check != -1) 
    	    return check;
    	OTGetTimeStamp(&timeStart);
	    return ioMicroMSecs();
	}else {
	    return ioMicroMSecsExpensive();
	}
}
#else
int ioMicroMSecs(void) {
    return ioMicroMSecsExpensive();
}
#endif

int ioMSecs(void) {
	/* return a time in milliseconds for use in Delays and Time millisecondClockValue */
	/* Note: This was once a macro based on clock(); it now uses the microsecond clock for
	   greater resolution. See the comment in ioMicroMSecs(). */
	return ioMicroMSecs();
}

int ioMousePoint(void) {
	Point p;

	ioProcessEvents();  /* process all pending events */
	if (windowActive) {
		GetMouse(&p);
	} else {
		/* don''t report mouse motion if window is not active */
		p = savedMousePosition;
	}
	return (p.h << 16) | (p.v & 0xFFFF);  /* x is high 16 bits; y is low 16 bits */
}

int ioPeekKeystroke(void) {
	int keystate;

	ioProcessEvents();  /* process all pending events */
	if (keyBufGet == keyBufPut) {
		return -1;  /* keystroke buffer is empty */
	} else {
		keystate = keyBuf[keyBufGet];
		/* set modifer bits in buttonState to reflect the last keystroke peeked at */
		buttonState = ((keystate >> 5) & 0xF8) | (buttonState & 0x7);
	}
	return keystate;
}

int ioProcessEvents(void) {
	/* This is a noop when running as a plugin; the browser handles events. */
	const int nextPollOffsetCheck = CLOCKS_PER_SEC/60, nextPowerCheckOffset=CLOCKS_PER_SEC/2; 
	static clock_t nextPollTick = 0, nextPowerCheck;
	long    clockTime;

#ifndef PLUGIN
	if (clock() >= nextPollTick) {
		/* time to process events! */
		while (HandleEvents()) {
			/* process all pending events */
		}
		
        clockTime = clock();
        
        if (gDisablePowerManager && gTapPowerManager) {
            if (clockTime > gDisableIdleTickLimit)
                gDisableIdleTickLimit = IdleUpdate() + gDisableIdleTickCount;
                
#if TARGET_CPU_PPC
            if (clockTime > nextPowerCheck) {
                 UpdateSystemActivity(UsrActivity);
                 nextPowerCheck = clockTime + nextPowerCheckOffset;
            }
#endif
        }
        
		/* wait a while before trying again */
		nextPollTick = clockTime + nextPollOffsetCheck;
	}
#endif
	return interruptPending;
}

int ioRelinquishProcessorForMicroseconds(int microSeconds) {
	/* This operation is platform dependent. On the Mac, it simply calls
	 * ioProcessEvents(), which gives other applications a chance to run.
	 */
   
    microSeconds;
	ioProcessEvents();  /* process all pending events */
}

#ifndef PLUGIN
int ioScreenSize(void) {
	int w = 10, h = 10;
    Rect portRect;
    
#ifndef IHAVENOHEAD
	if (stWindow != nil) {
        GetPortBounds(GetWindowPort(stWindow),&portRect);
		w =  portRect.right -  portRect.left;
		h =  portRect.bottom - portRect.top;
	}
#endif
	return (w << 16) | (h & 0xFFFF);  /* w is high 16 bits; h is low 16 bits */
}
#endif

int ioSeconds(void) {
	struct tm timeRec;
	time_t time1904, timeNow;

	/* start of ANSI epoch is midnight of Jan 1, 1904 */
	timeRec.tm_sec   = 0;
	timeRec.tm_min   = 0;
	timeRec.tm_hour  = 0;
	timeRec.tm_mday  = 1;
	timeRec.tm_mon   = 0;
	timeRec.tm_year  = 4;
	timeRec.tm_wday  = 0;
	timeRec.tm_yday  = 0;
	timeRec.tm_isdst = 0;
	time1904 = mktime(&timeRec);

	timeNow = time(NULL);

	/* Squeak epoch is Jan 1, 1901, 3 non-leap years earlier than ANSI one */
	return (timeNow - time1904) + (3 * 365 * 24 * 60 * 60);
}

int ioSetCursor(int cursorBitsIndex, int offsetX, int offsetY) {
	/* Old version; forward to new version. */
	ioSetCursorWithMask(cursorBitsIndex, nil, offsetX, offsetY);
}

int ioSetCursorWithMask(int cursorBitsIndex, int cursorMaskIndex, int offsetX, int offsetY) {
	/* Set the 16x16 cursor bitmap. If cursorMaskIndex is nil, then make the mask the same as
	   the cursor bitmap. If not, then mask and cursor bits combined determine how cursor is
	   displayed:
			mask	cursor	effect
			 0		  0		transparent (underlying pixel shows through)
			 1		  1		opaque black
			 1		  0		opaque white
			 0		  1		invert the underlying pixel
	*/
	Cursor macCursor;
	int i;

	if (cursorMaskIndex == nil) {
		for (i = 0; i < 16; i++) {
			macCursor.data[i] = (checkedLongAt(cursorBitsIndex + (4 * i)) >> 16) & 0xFFFF;
			macCursor.mask[i] = (checkedLongAt(cursorBitsIndex + (4 * i)) >> 16) & 0xFFFF;
		}
	} else {
		for (i = 0; i < 16; i++) {
			macCursor.data[i] = (checkedLongAt(cursorBitsIndex + (4 * i)) >> 16) & 0xFFFF;
			macCursor.mask[i] = (checkedLongAt(cursorMaskIndex + (4 * i)) >> 16) & 0xFFFF;
		}
	}

	/* Squeak hotspot offsets are negative; Mac''s are positive */
	macCursor.hotSpot.h = -offsetX;
	macCursor.hotSpot.v = -offsetY;
	SetCursor(&macCursor);
}

int ioSetDisplayMode(int width, int height, int depth, int fullscreenFlag) {
	/* Set the window to the given width, height, and color depth. Put the window
	   into the full screen mode specified by fullscreenFlag. */
	/* Note: Changing display depth is not yet, and may never be, implemented
	   on the Macintosh, where (a) it is considered inappropriate and (b) it may
	   not even be a well-defined operation if the Squeak window spans several
	   displays (which display''s depth should be changed?). */

	depth;
#ifndef IHAVENOHEAD
	ioSetFullScreen(fullscreenFlag);
	if (!fullscreenFlag) {
		SizeWindow(stWindow, width, height, true);
	}
#endif
}

#ifndef PLUGIN
int ioSetFullScreen(int fullScreen) {
	Rect screen,portRect;
	BitMap bmap;
	int width, height, maxWidth, maxHeight;
	int oldWidth, oldHeight;
			
	GetQDGlobalsScreenBits(&bmap);
    screen = bmap.bounds;
    
	if (fullScreen) {
		MenuBarHide();
		GetPortBounds(GetWindowPort(stWindow),&portRect);
		oldWidth =  portRect.right -  portRect.left;
		oldHeight =  portRect.bottom -  portRect.top;
		width  = screen.right - screen.left; 
		height = (screen.bottom - screen.top);
		if ((oldWidth < width) || (oldHeight < height)) {
			/* save old size if it wasn''t already full-screen */ 
			savedWindowSize = (oldWidth << 16) + (oldHeight & 0xFFFF);
		}
		MoveWindow(stWindow, 0, 0, true);
		SizeWindow(stWindow, width, height, true);
		fullScreenFlag = true;
	} else {
		MenuBarRestore();

		/* get old window size */
		width  = (unsigned) savedWindowSize >> 16;
		height = savedWindowSize & 0xFFFF;

		/* minimum size is 64 x 64 */
		width  = (width  > 64) ?  width : 64;
		height = (height > 64) ? height : 64;

		/* maximum size is screen size inset slightly */
		maxWidth  = (screen.right  - screen.left) - 16;
		maxHeight = (screen.bottom - screen.top)  - 52;
		width  = (width  <= maxWidth)  ?  width : maxWidth;
		height = (height <= maxHeight) ? height : maxHeight;
		MoveWindow(stWindow, 8, 44, true);
		SizeWindow(stWindow, width, height, true);
		fullScreenFlag = false;
	}
}
#endif


int ioShowDisplay(
	int dispBitsIndex, int width, int height, int depth,
	int affectedL, int affectedR, int affectedT, int affectedB) {

	Rect		dstRect = { 0, 0, 0, 0 };
	Rect		srcRect = { 0, 0, 0, 0 };
	RgnHandle	maskRect = nil;

	if (stWindow == nil) {
		return;
	}

	dstRect.left	= 0;
	dstRect.top		= 0;
	dstRect.right	= width;
	dstRect.bottom	= height;

	srcRect.left	= 0;
	srcRect.top		= 0;
	srcRect.right	= width;
	srcRect.bottom	= height;

	(*stPixMap)->baseAddr = (void *) dispBitsIndex;
	/* Note: top three bits of rowBytes indicate this is a PixMap, not a BitMap */
	(*stPixMap)->rowBytes = (((((width * depth) + 31) / 32) * 4) & 0x1FFF) | 0x8000;
	(*stPixMap)->bounds = srcRect;
	(*stPixMap)->pixelSize = depth;

    if (depth<=8) { /*Duane Maxwell <dmaxwell@exobox.com> fix cmpSize Sept 18,2000 */
    	(*stPixMap)->cmpSize = depth;
    	(*stPixMap)->cmpCount = 1;
    } else if (depth==16) {
    	(*stPixMap)->cmpSize = 5;
    	(*stPixMap)->cmpCount = 3;
    } else if (depth==32) {
    	(*stPixMap)->cmpSize = 8;
    	(*stPixMap)->cmpCount = 3;
    }

	/* create a mask region so that only the affected rectangle is copied */
	maskRect = NewRgn();
	SetRectRgn(maskRect, affectedL, affectedT, affectedR, affectedB);

	SetPortWindowPort(stWindow);
	CopyBits((BitMap *) *stPixMap, GetPortBitMapForCopyBits(GetWindowPort(stWindow)), &srcRect, &dstRect, srcCopy, maskRect);
#if TARGET_API_MAC_CARBON
	QDFlushPortBuffer (GetWindowPort(stWindow), maskRect);
#endif
	DisposeRgn(maskRect);
}


/*** Image File Naming ***/

void StoreFullPathForLocalNameInto(char *shortName, char *fullName, int length, short volumeNumber,long directoryID) {
	int offset, sz, i;

	offset = PathToWorkingDir(fullName, length, volumeNumber, directoryID);

	/* copy the file name into a null-terminated C string */
	sz = strlen(shortName);
	for (i = 0; i <= sz; i++) {
		/* append shortName to fullName, including terminator */
		fullName[i + offset] = shortName[i];
	}
}

int imageNameSize(void) {
	return strlen(imageName);
}

int imageNameGetLength(int sqImageNameIndex, int length) {
	char *sqImageName = (char *) sqImageNameIndex;
	int count, i;

	count = strlen(imageName);
	count = (length < count) ? length : count;

	/* copy the file name into the Squeak string */
	for (i = 0; i < count; i++) {
		sqImageName[i] = imageName[i];
	}
	return count;
}

int imageNamePutLength(int sqImageNameIndex, int length) {
	char *sqImageName = (char *) sqImageNameIndex;
	int count, i, ch, j;
	int lastColonIndex = -1;

	count = (IMAGE_NAME_SIZE < length) ? IMAGE_NAME_SIZE : length;

	/* copy the file name into a null-terminated C string */
	for (i = 0; i < count; i++) {
		ch = imageName[i] = sqImageName[i];
		if (ch == '':'') {
			lastColonIndex = i;
		}
	}
	imageName[count] = 0;

	/* copy short image name into a null-terminated C string */
	for (i = lastColonIndex + 1, j = 0; i < count; i++, j++) {
		shortImageName[j] = imageName[i];
	}
	shortImageName[j] = 0;

	SetWindowTitle(shortImageName);
	return count;
}

/*****************************************************************************************
GetApplicationDirectory

Get the volume reference number and directory id of this application.
Code taken from Apple:
	Technical Q&As: FL 14 - Finding your application''s directory (19-June-2000)

Karl Goiser 14/01/01
*****************************************************************************************/

        /* GetApplicationDirectory returns the volume reference number
        and directory ID for the current application''s directory. */

    OSStatus GetApplicationDirectory(short *vRefNum, long *dirID) {
        ProcessSerialNumber PSN;
        ProcessInfoRec pinfo;
        FSSpec pspec;
        OSStatus err;
            /* valid parameters */
        if (vRefNum == NULL || dirID == NULL) return paramErr;
            /* set up process serial number */
        PSN.highLongOfPSN = 0;
        PSN.lowLongOfPSN = kCurrentProcess;
            /* set up info block */
        pinfo.processInfoLength = sizeof(pinfo);
        pinfo.processName = NULL;
        pinfo.processAppSpec = &pspec;
            /* grab the vrefnum and directory */
        err = GetProcessInformation(&PSN, &pinfo);
        if (err == noErr) {
            *vRefNum = pspec.vRefNum;
            *dirID = pspec.parID;
        }
        return err;
    }


/*** Initializing the path to Working Dir ***/

int PathToWorkingDir(char *pathName, int pathNameMax, short volumeNumber,long directoryID) {
	/* Fill in the given string with the full path from a root volume to
	   to current working directory. (At startup time, the working directory
	   is set to the application''s directory. Fails if the given string is not
	   long enough to hold the entire path. (Use at least 1000 characters to
	   be safe.)
	*/

	short	fullPathLength;
	Handle	fullPathHandle;

	if (GetFullPath(volumeNumber, directoryID, nil, &fullPathLength, &fullPathHandle) != noErr) {
		//Some sort of random guff for failure:
		pathName[0] = 1;
		pathName[1] = (char)":";
		return 1;
	}

	strncpy((char *) pathName, (char *) *fullPathHandle, fullPathLength);
	DisposeHandle(fullPathHandle);
	return fullPathLength;
}

pascal	OSErr	GetFullPath(short vRefNum,
							long dirID,
							ConstStr255Param name,
							short *fullPathLength,
							Handle *fullPath)
{
	OSErr		result;
	FSSpec		spec;
	
	*fullPathLength = 0;
	*fullPath = NULL;
	
	result = FSMakeFSSpecCompat(vRefNum, dirID, name, &spec);
	if ( (result == noErr) || (result == fnfErr) )
	{
		result = FSpGetFullPath(&spec, fullPathLength, fullPath);
	}
	
	return ( result );
}

pascal	OSErr	FSpGetFullPath(const FSSpec *spec,
							   short *fullPathLength,
							   Handle *fullPath)
{
	OSErr		result;
	OSErr		realResult;
	FSSpec		tempSpec;
	CInfoPBRec	pb;
	
	*fullPathLength = 0;
	*fullPath = NULL;
	
	
	/* Default to noErr */
	realResult = result = noErr;
	
#if 0
//The following code doesn''t seem to work in OS X, the BloackMoveData crashes the
// machine, the the FSMakeFSSpecCompat works, so go figure...  KG 4/1/01

	/* work around Nav Services "bug" (it returns invalid FSSpecs with empty names) */
	if ( spec->name[0] == 0 )
	{
		result = FSMakeFSSpecCompat(spec->vRefNum, spec->parID, spec->name, &tempSpec);
	}
	else
	{
		/* Make a copy of the input FSSpec that can be modified */
		BlockMoveData(spec, &tempSpec, sizeof(FSSpec));
	}
#endif 0

	result = FSMakeFSSpecCompat(spec->vRefNum, spec->parID, spec->name, &tempSpec);


	if ( result == noErr )
	{
		if ( tempSpec.parID == fsRtParID )
		{
			/* The object is a volume */
			
			/* Add a colon to make it a full pathname */
			++tempSpec.name[0];
			tempSpec.name[tempSpec.name[0]] = '':'';
			
			/* We''re done */
			result = PtrToHand(&tempSpec.name[1], fullPath, tempSpec.name[0]);
			*fullPathLength = tempSpec.name[0];
		}
		else
		{
			/* The object isn''t a volume */
			
			/* Is the object a file or a directory? */
			pb.dirInfo.ioNamePtr = tempSpec.name;
			pb.dirInfo.ioVRefNum = tempSpec.vRefNum;
			pb.dirInfo.ioDrDirID = tempSpec.parID;
			pb.dirInfo.ioFDirIndex = 0;
			result = PBGetCatInfoSync(&pb);
			// Allow file/directory name at end of path to not exist.
			realResult = result;
			if ( (result == noErr) || (result == fnfErr) )
			{
				/* if the object is a directory, append a colon so full pathname ends with colon */
				if ( (result == noErr) && (pb.hFileInfo.ioFlAttrib & kioFlAttribDirMask) != 0 )
				{
					++tempSpec.name[0];
					tempSpec.name[tempSpec.name[0]] = '':'';
				}
				
				/* Put the object name in first */
				result = PtrToHand(&tempSpec.name[1], fullPath, tempSpec.name[0]);
				*fullPathLength = tempSpec.name[0];
				if ( result == noErr )
				{
					/* Get the ancestor directory names */
					pb.dirInfo.ioNamePtr = tempSpec.name;
					pb.dirInfo.ioVRefNum = tempSpec.vRefNum;
					pb.dirInfo.ioDrParID = tempSpec.parID;
					do	/* loop until we have an error or find the root directory */
					{
						pb.dirInfo.ioFDirIndex = -1;
						pb.dirInfo.ioDrDirID = pb.dirInfo.ioDrParID;
						result = PBGetCatInfoSync(&pb);
						if ( result == noErr )
						{
							/* Append colon to directory name */
							++tempSpec.name[0];
							tempSpec.name[tempSpec.name[0]] = '':'';
							
							/* Add directory name to beginning of fullPath */
							(void) Munger(*fullPath, 0, NULL, 0, &tempSpec.name[1], tempSpec.name[0]);
							*fullPathLength += tempSpec.name[0];
							result = MemError();
						}
					} while ( (result == noErr) && (pb.dirInfo.ioDrDirID != fsRtDirID) );
				}
			}
		}
	}
	
	if ( result == noErr )
	{
		/* Return the length */
///		*fullPathLength = GetHandleSize(*fullPath);
		result = realResult;	// return realResult in case it was fnfErr
	}
	else
	{
		/* Dispose of the handle and return NULL and zero length */
		if ( *fullPath != NULL )
		{
			DisposeHandle(*fullPath);
		}
		*fullPath = NULL;
		*fullPathLength = 0;
	}
	
	return ( result );
}

/*****************************************************************************/

pascal OSErr FSpLocationFromFullPath(short fullPathLength,
									 const void *fullPath,
									 FSSpec *spec)
{
	AliasHandle	alias;
	OSErr		result;
	Boolean		wasChanged;
	Str32		nullString;
	
	/* Create a minimal alias from the full pathname */
	nullString[0] = 0;	/* null string to indicate no zone or server name */
	result = NewAliasMinimalFromFullPath(fullPathLength, fullPath, nullString, nullString, &alias);
	if ( result == noErr )
	{
		/* Let the Alias Manager resolve the alias. */
		result = ResolveAlias(NULL, alias, spec, &wasChanged);
		
		/* work around Alias Mgr sloppy volume matching bug */
		if ( spec->vRefNum == 0 )
		{
			/* invalidate wrong FSSpec */
			spec->parID = 0;
			spec->name[0] =  0;
			result = nsvErr;
		}
		DisposeHandle((Handle)alias);	/* Free up memory used */
	}
	return ( result );
}
/*****************************************************************************/

/*
**	File Manager FSp calls
*/

/*****************************************************************************/

pascal	OSErr	FSMakeFSSpecCompat(short vRefNum,
								   long dirID,
								   ConstStr255Param fileName,
								   FSSpec *spec)
{
	OSErr	result;
	
	/* Let the file system create the FSSpec if it can since it does the job */
	/* much more efficiently than I can. */
	result = FSMakeFSSpec(vRefNum, dirID, fileName, spec);

	/* Fix a bug in Macintosh PC Exchange''s MakeFSSpec code where 0 is */
	/* returned in the parID field when making an FSSpec to the volume''s */
	/* root directory by passing a full pathname in MakeFSSpec''s */
	/* fileName parameter. Fixed in Mac OS 8.1 */
	if ( (result == noErr) && (spec->parID == 0) )
		spec->parID = fsRtParID;
	return ( result );
}

int PrefixPathWith(char *pathName, int pathNameSize, int pathNameMax, char *prefix) {
	/* Insert the given prefix C string plus a delimitor character at the
	   beginning of the given C string. Return the new pathName size. Fails
	   if pathName is does not have sufficient space for the result.
	   Assume: pathName is null terminated.
	*/

	int offset, i;

	offset = strlen(prefix) + 1;
	if ((pathNameSize + offset) > pathNameMax) {
		return pathNameSize;
	}

	for (i = pathNameSize; i >= 0; i--) {
		/* make room in pathName for prefix (moving string terminator, too) */
		pathName[i + offset] = pathName[i];
	}
	for (i = 0; i < offset; i++) {
		/* make room in pathName for prefix */
		pathName[i] = prefix[i];
	}
	pathName[offset - 1] = '':'';  /* insert delimitor */
	return pathNameSize + offset;
}


/*** Profiling ***/

int clearProfile(void) {
#ifdef MAKE_PROFILE
	ProfilerClear();
#endif
}

int dumpProfile(void) {
#ifdef MAKE_PROFILE
	ProfilerDump("\pProfile.out");
#endif
}

int startProfiling(void) {
#ifdef MAKE_PROFILE
	ProfilerSetStatus(true);
#endif
}

int stopProfiling(void) {
#ifdef MAKE_PROFILE
	ProfilerSetStatus(false);
#endif
}

/*** Plugin Support ***/

int plugInInit(char *fullImagePath) {

	fullImagePath;
	/* check the interpreter''s size assumptions for basic data types */
	if (sizeof(int) != 4) {
		error("This C compiler''s integers are not 32 bits.");
	}
	if (sizeof(double) != 8) {
		error("This C compiler''s floats are not 64 bits.");
	}
	if (sizeof(time_t) != 4) {
		error("This C compiler''s time_t''s are not 32 bits.");
	}

	/* clear all path and file names */
	imageName[0] = shortImageName[0] = documentName[0] = vmPath[0] = 0;

#if TARGET_CPU_PPC
	if((Ptr)OTGetTimeStamp!=(Ptr)kUnresolvedCFragSymbolAddress)
 	    OTGetTimeStamp(&timeStart);
#endif

	PowerMgrCheck();
	SetUpClipboard();
	SetUpPixmap();
	dropInit();
}

int plugInShutdown(void) {
	ioShutdownAllModules();
	FreeClipboard();
	FreePixmap();
	if (memory != nil) {
		DisposePtr((void *) memory);
		memory = nil;
	}
}

#ifndef PLUGIN
int plugInAllowAccessToFilePath(char *pathString, int pathStringLength) {
  /* Grant permission to all files. */
	pathString; pathStringLength;
	return true;
}
#endif

/*** System Attributes ***/

int IsImageName(char *name) {
	char *suffix;

	suffix = strrchr(name, ''.'');  /* pointer to last period in name */
	if (suffix == NULL) return false;
	if (strcmp(suffix, ".ima") == 0) return true;
	if (strcmp(suffix, ".image") == 0) return true;
	if (strcmp(suffix, ".IMA") == 0) return true;
	if (strcmp(suffix, ".IMAGE") == 0) return true;
	return false;
}

char * GetAttributeString(int id) {
	/* This is a hook for getting various status strings back from
	   the OS. In particular, it allows Squeak to be passed arguments
	   such as the name of a file to be processed. Command line options
	   are reported this way as well, on platforms that support them.
	*/

	// id #0 should return the full name of VM; for now it just returns its path
	if (id == 0) return vmPath;
	/* Note: 1.3x images will try to read the image as a document because they
	   expect attribute #1 to be the document name. A 1.3x image can be patched
	   using a VM of 2.6 or earlier. */
	if (id == 1) return imageName;
	if (id == 2) return documentName;

#ifdef PLUGIN
	/* When running in browser, return the EMBED tag info */
	if ((id > 2) && (id <= (2 + (2 * pluginArgCount)))) {
		int i = id - 3;
		if ((i & 1) == 0) {  /* i is even */
			return pluginArgName[i/2];
		} else {
			return pluginArgValue[i/2];
		}
	}
#endif

	if (id == 1001) return "Mac OS";
	if (id == 1002) return "System 7 or Later";
	if (id == 1003) return "PowerPC or 68K";

	/* attribute undefined by this platform */
	success(false);
	return "";
}

int attributeSize(int id) {
	return strlen(GetAttributeString(id));
}

int getAttributeIntoLength(int id, int byteArrayIndex, int length) {
	char *srcPtr, *dstPtr, *end;
	int charsToMove;

	srcPtr = GetAttributeString(id);
	charsToMove = strlen(srcPtr);
	if (charsToMove > length) {
		charsToMove = length;
	}

	dstPtr = (char *) byteArrayIndex;
	end = srcPtr + charsToMove;
	while (srcPtr < end) {
		*dstPtr++ = *srcPtr++;
	}
	return charsToMove;
}

/*** Image File Operations ***/

void sqImageFileClose(sqImageFile f) {
	FSClose(f);
}

sqImageFile sqImageFileOpen(char *fileName, char *mode) {
	short int err, err2, fRefNum;
	Str255 tempPascalFileName; 
    FInfo fileInfo;

	CopyCStringToPascal(fileName,tempPascalFileName);
	if (strchr(mode, ''w'') != null) 
	    err = HOpenDF(0,0,tempPascalFileName,fsRdWrPerm, &fRefNum);
	 else
	    err = HOpenDF(0,0,tempPascalFileName,fsRdPerm, &fRefNum);
	    
	if ((err != 0) && (strchr(mode, ''w'') != null)) {
		/* creating a new file for "save as" */
		err2 = HCreate(0,0,tempPascalFileName,  ''FAST'', ''STim'');
		if (err2 == 0) {
			err = HOpenDF(0,0,tempPascalFileName,fsRdWrPerm, &fRefNum);
		}
	}

	if (err != 0) return null;

	if (strchr(mode, ''w'') != null) {
        err = HGetFInfo(0,0,tempPascalFileName,&fileInfo);
        if (err != noErr) return 0; //This should not happen
        
        //On the mac we start at location 0 if this isn''t an VM
        
    	if (!(fileInfo.fdType == ''APPL'' && fileInfo.fdCreator == ''FAST'')){
    		/* truncate non-VM file if opening in write mode */
    		err = SetEOF(fRefNum, 0);
    		if (err != 0) {
    			FSClose(fRefNum);
    			return null;
    		}
	    }
	}
	return (sqImageFile) fRefNum;
}

int sqImageFilePosition(sqImageFile f) {
	long int currentPosition = 0;

	GetFPos(f, &currentPosition);
	return currentPosition;
}

int sqImageFileRead(void *ptr, int elementSize, int count, sqImageFile f) {
	long int byteCount = elementSize * count;
	short int err;

	err = FSRead(f, &byteCount, ptr);
	if (err != 0) return 0;
	return byteCount / elementSize;
}

void sqImageFileSeek(sqImageFile f, int pos) {
	SetFPos(f, fsFromStart, pos);
}

int sqImageFileWrite(void *ptr, int elementSize, int count, sqImageFile f) {
	long int byteCount = elementSize * count;
	short int err;

	err = FSWrite(f, &byteCount, ptr);
	if (err != 0) return 0;
	return byteCount / elementSize;
}

int calculateStartLocationForImage() { 

	Handle cfrgResource;  
	long	memberCount,i;
	CFragResourceMember *target;
	Str255 tempPascalFileName;
	OSErr   err;
    int     resFileRef;
	
	cfrgResource = GetResource(kCFragResourceType,0); 
	if (cfrgResource == nil || ResError() != noErr) { return 0;};  
	
	memberCount = ((CFragResource *)(*cfrgResource))->memberCount;
	if (memberCount <= 1) {
        ReleaseResource(cfrgResource);
	    return 0; //Need FAT to get counters right
	}
	
	target = &((CFragResource *)(*cfrgResource))->firstMember;
	for(i=0;i<memberCount;i++) {
		if (target->architecture == ''FAST'') {			
		    ReleaseResource(cfrgResource);
		    return target->offset;
		}
		target = NextCFragResourceMemberPtr(target); 
	}
    ReleaseResource(cfrgResource);
	return 0;
}

int sqImageFileStartLocation(int fileRef, char *filename, int imageSize){
    FInfo fileInfo;
	Str255 tempPascalFileName;
	OSErr   err; 
    int     resFileRef;
	Handle  cfrgResource,newcfrgResource;  
	UInt32	maxOffset=0,maxOffsetLength,targetOffset;
	long    memberCount,i;
	CFragResourceMember *target;
  
    
	CopyCStringToPascal(filename,tempPascalFileName);
    err = HGetFInfo(0,0,tempPascalFileName,&fileInfo);
    if (err != noErr) return 0; //This should not happen
    
    //On the mac we start at location 0 if this isn''t an VM
    
	if (!(fileInfo.fdType == ''APPL'' && fileInfo.fdCreator == ''FAST'')) return 0;
    
    //Ok we have an application file, open the resource part and attempt to find the crfg
    
    resFileRef = HOpenResFile(0,0,tempPascalFileName,fsWrPerm);
    if (resFileRef == -1) return 0;
    
	cfrgResource = GetResource(kCFragResourceType,0);
	if (cfrgResource == nil || ResError() != noErr) {CloseResFile(resFileRef); return 0;};  
	
	memberCount = ((CFragResource *)(*cfrgResource))->memberCount;
	if (memberCount <= 1) {ReleaseResource(cfrgResource); CloseResFile(resFileRef); return 0;};  //Need FAT to get counters right
	
	target = &((CFragResource *)(*cfrgResource))->firstMember;
	for(i=0;i<memberCount;i++) {
		if (target->architecture == ''FAST'') {
		    targetOffset = target->offset;
		    target->length = imageSize;
		    ChangedResource(cfrgResource);
        	if (ResError() != noErr) {ReleaseResource(cfrgResource); CloseResFile(resFileRef); return 0;}; 
		    UpdateResFile(resFileRef);
        	if (ResError() != noErr) {ReleaseResource(cfrgResource); CloseResFile(resFileRef); return 0;}; 
            ReleaseResource(cfrgResource); 
		    CloseResFile(resFileRef);
			return targetOffset;
		}
		if (target->offset > maxOffset) {
			maxOffset = target->offset;
			maxOffsetLength = target->length;
		}
		target = NextCFragResourceMemberPtr(target);
	}
	
	//Ok at this point we need to alter the crfg to add the new tag for the image part
	
	newcfrgResource = cfrgResource;
	err = HandToHand(&newcfrgResource);
	if (err != noErr || MemError() != noErr)  {ReleaseResource(cfrgResource); CloseResFile(resFileRef); return 0;}; 
	SetHandleSize(newcfrgResource,GetHandleSize(cfrgResource)+AlignToFour(kBaseCFragResourceMemberSize + 1));
	if (MemError() != noErr)  {ReleaseResource(cfrgResource); CloseResFile(resFileRef); return 0;}; 
	
	target = &((CFragResource *)(*newcfrgResource))->firstMember; 
	for(i=0;i<memberCount;i++) {
		target = NextCFragResourceMemberPtr(target); 
	}

    target->architecture = ''FAST'';
    target->reservedA = 0;                  /* ! Must be zero!*/
    target->reservedB = 0;                  /* ! Must be zero!*/
    target->updateLevel = 0;
    target->currentVersion = 0;
    target->oldDefVersion = 0;
    target->uUsage1.appStackSize = 0;
    target->uUsage2.appSubdirID = 0;
    target->uUsage2.libFlags = 0;
    target->usage = kApplicationCFrag;
    target->where = kDataForkCFragLocator;
    target->offset = maxOffset + maxOffsetLength;
    targetOffset = target->offset;
    target->length = imageSize;
    target->uWhere1.spaceID = 0;
    target->extensionCount = 0;             /* The number of extensions beyond the name.*/
    target->memberSize = AlignToFour(kBaseCFragResourceMemberSize + 1);   /* Size in bytes, includes all extensions.*/
    target->name[0] = 0x00;

	((CFragResource *)(*newcfrgResource))->memberCount = memberCount+1;
	RemoveResource(cfrgResource);
	if (ResError() != noErr) {CloseResFile(resFileRef); return 0;}; 
 	AddResource(newcfrgResource,kCFragResourceType,0,nil);
	if (ResError() != noErr) {CloseResFile(resFileRef); return 0;}; 
    UpdateResFile(resFileRef);
	if (ResError() != noErr) {CloseResFile(resFileRef); return 0;}; 
    CloseResFile(resFileRef);
    
	return targetOffset;
}

#ifndef PLUGIN
void * sqAllocateMemory(int minHeapSize, int desiredHeapSize) {
	/* Application allocates Squeak object heap memory from its own heap. */	
	minHeapSize;
	return NewPtr(desiredHeapSize);;
}
#endif

void PowerMgrCheck(void) {
	long pmgrAttributes;
	
	gTapPowerManager = false;
	gDisablePowerManager = false;
	if (! Gestalt(gestaltPowerMgrAttr, &pmgrAttributes))
		if ((pmgrAttributes & (1<<gestaltPMgrExists)) 
		    && (pmgrAttributes & (1<<gestaltPMgrDispatchExists))
		    && (PMSelectorCount() >= 0x24)) {
		    gTapPowerManager = true;
			gDisableIdleTickLimit = clock();
		}
}

int ioDisablePowerManager(int disableIfNonZero) {
    gDisablePowerManager = disableIfNonZero;
}

Boolean RunningOnCarbonX(void)
{
    UInt32 response;
    
    return (Gestalt(gestaltSystemVersion, 
                    (SInt32 *) &response) == noErr)
                && (response >= 0x01000);
}

/*** Main ***/

#ifndef PLUGIN
void main(void) {
	EventRecord theEvent;
	sqImageFile f;
	int reservedMemory, availableMemory;

	short vRefNum;
	long dirID;
	OSErr err;

	InitMacintosh();
	PowerMgrCheck();
	
	SetUpMenus();
	SetUpClipboard();
	SetUpWindow();
	SetUpPixmap();
	dropInit();
	SetEventMask(everyEvent); // also get key up events
	
#if TARGET_CPU_PPC
	if((Ptr)OTGetTimeStamp!=(Ptr)kUnresolvedCFragSymbolAddress)
 	    OTGetTimeStamp(&timeStart);
#endif 

	/* install apple event handlers and wait for open event */
	imageName[0] = shortImageName[0] = documentName[0] = vmPath[0] = 0;
	InstallAppleEventHandlers();
	while (shortImageName[0] == 0) {
		GetNextEvent(everyEvent, &theEvent);
		if (theEvent.what == kHighLevelEvent) {
			AEProcessAppleEvent(&theEvent);
		}
	}
	if (imageName[0] == 0) {
		err = GetApplicationDirectory(&vRefNum, &dirID);
		if (err != noErr) error("Could not obtain default directory");
		StoreFullPathForLocalNameInto(shortImageName, imageName, IMAGE_NAME_SIZE, vRefNum, dirID);
	}

	/* check the interpreter''s size assumptions for basic data types */
	if (sizeof(int) != 4) {
		error("This C compiler''s integers are not 32 bits.");
	}
	if (sizeof(double) != 8) {
		error("This C compiler''s floats are not 64 bits.");
	}
	if (sizeof(time_t) != 4) {
		error("This C compiler''s time_t''s are not 32 bits.");
	}

#ifdef MAKE_PROFILE
	ProfilerInit(collectDetailed, bestTimeBase, 1000, 50);
	ProfilerSetStatus(false);
	ProfilerClear();
#endif

	/* compute the desired memory allocation */
	reservedMemory = 500000;
	if (RunningOnCarbonX())
	    availableMemory = 100*1024*1024 - reservedMemory;
	else 
    	availableMemory = MaxBlock() - reservedMemory;
	
	/******
	  Note: This is platform-specific. On the Mac, the user specifies the desired
	    memory partition for each application using the Finder''s Get Info command.
	    MaxBlock() returns the amount of memory in the partition minus space for
	    the code segment and other resources. On other platforms, the desired heap
	    size would be specified in other ways (e.g, via a command line argument).
	    The maximum size of the object heap is fixed at at startup. If you run low
	    on space, you must save the image and restart with more memory.

	  Note: Some memory must be reserved for Mac toolbox calls, sound buffers, etc.
	    A 30K reserve is too little. 40K allows Squeal to run but crashes if the
	    console is opened. 50K allows the console to be opened (with and w/o the
	    profiler). I added another 30K to provide for sound buffers and reliability.
	    (Note: Later discovered that sound output failed if SoundManager was not
	    preloaded unless there is about 100K reserved. Added 50K to that.)
	    
	    JMM Note changed to 500 for Open Transport support on 68K machines
	******/

	/* uncomment the following when using the C transcript window for debugging: */
	//printf("Move this window, then hit CR\n"); getchar();

	/* read the image file and allocate memory for Squeak heap */
	f = sqImageFileOpen(imageName, "rb");
	if (f == NULL) {
		/* give a Mac-specific error message if image file is not found */
		printf("Could not open the Squeak image file ''%s''\n\n", imageName);
		printf("There are several ways to open a Squeak image file. You can:\n");
		printf("  1. Double-click on the desired image file.\n");
		printf("  2. Drop the image file icon onto the Squeak application or an alias to it.\n");
		printf("  3. Name your image ''squeak.image'' and put it in the same folder as the\n");
		printf("     Squeak application, then double-click on the Squeak application.\n\n");
		printf("Press the return key to exit.\n");
		getchar();
		printf("Aborting...\n");
		ioExit();
	}
	readImageFromFileHeapSizeStartingAt(f, availableMemory, calculateStartLocationForImage());
	sqImageFileClose(f);

#ifndef IHAVENOHEAD
	SetWindowTitle(shortImageName);
	ioSetFullScreen(fullScreenFlag);
#endif
	/* run Squeak */
	interpret();
}
#endif

void SqueakTerminate() {
#ifdef PLUGIN
	ExitCleanup();
#else
	ioShutdownAllModules();
#endif
}

WindowPtr getSTWindow(void) {
    return stWindow;
}

int setMessageHook(eventMessageHook theHook) {
    messageHook = theHook;
}

int setPostMessageHook(eventMessageHook theHook) {
    postMessageHook = theHook;
}

#if !TARGET_API_MAC_CARBON
//
//	CopyPascalStringToC converts the source pascal string to a destination
//	C string as it copies. 
//
void CopyPascalStringToC(ConstStr255Param src, char* dst)
{
	if ( src != NULL )
	{
		short   length  = *src++;
	
		while ( length > 0 ) 
		{
			*dst++ = *(char*)src++;
			--length;
		}
	}
	*dst = ''\0'';
}


//
//	CopyCStringToPascal converts the source C string to a destination
//	pascal string as it copies. The dest string will
//	be truncated to fit into an Str255 if necessary.
//  If the C String pointer is NULL, the pascal string''s length is set to zero
//
void CopyCStringToPascal(const char* src, Str255 dst)
{
	short 	length  = 0;
	
	// handle case of overlapping strings
	if ( (void*)src == (void*)dst )
	{
		unsigned char*		curdst = &dst[1];
		unsigned char		thisChar;
				
		thisChar = *(const unsigned char*)src++;
		while ( thisChar != ''\0'' ) 
		{
			unsigned char	nextChar;
			
			// use nextChar so we don''t overwrite what we are about to read
			nextChar = *(const unsigned char*)src++;
			*curdst++ = thisChar;
			thisChar = nextChar;
			
			if ( ++length >= 255 )
				break;
		}
	}
	else if ( src != NULL )
	{
		unsigned char*		curdst = &dst[1];
		short 				overflow = 255;		// count down so test it loop is faster
		register char		temp;
	
		// Can''t do the K&R C thing of Òwhile (*s++ = *t++)Ó because it will copy trailing zero
		// which might overrun pascal buffer.  Instead we use a temp variable.
		while ( (temp = *src++) != 0 ) 
		{
			*(char*)curdst++ = temp;
				
			if ( --overflow <= 0 )
				break;
		}
		length = 255 - overflow;
	}
	dst[0] = length;
}
#endif

'