macWindowFile

	^ '#include <MacHeaders.h>
#include <AppleEvents.h>
#include <Dialogs.h>
#include <Devices.h>
#include <Files.h>
#include <Fonts.h>
#include <Gestalt.h>
#include <Menus.h>
#include <OSUtils.h>
#include <Power.h>
#include <Scrap.h>
#include <Strings.h>
#include <Timer.h>
#include <ToolUtils.h>
#include <Windows.h>
#include <profiler.h>

#include "sq.h"

/*** Compilation Options:
*
*	define PLUGIN		to compile code for Netscape Plug-in
*	define MAKE_PROFILE	to compile code for profiling
*
***/

//#define PLUGIN
//#define MAKE_PROFILE

/*** Enumerations ***/
enum { appleID = 1, fileID, editID };
enum { quitItem = 1 };

/*** Variables -- Imported from Virtual Machine ***/
extern int fullScreenFlag;
extern int interruptCheckCounter;
extern int interruptKeycode;
extern int interruptPending;  /* set to true by recordKeystroke if interrupt key is pressed */
extern unsigned char *memory;
extern int savedWindowSize;   /* set from header when image file is loaded */

/*** Variables -- image and path names ***/
#define IMAGE_NAME_SIZE 300
char imageName[IMAGE_NAME_SIZE + 1];  /* full path to image */

#define SHORTIMAGE_NAME_SIZE 100
char shortImageName[SHORTIMAGE_NAME_SIZE + 1];  /* just the image file name */

#define DOCUMENT_NAME_SIZE 300
char documentName[DOCUMENT_NAME_SIZE + 1];  /* full path to document or image file */

#define SHORTDOCUMENT_NAME_SIZE 100
char shortDocumentName[SHORTDOCUMENT_NAME_SIZE + 1];  /* just the document file name */

#define VMPATH_SIZE 300
char vmPath[VMPATH_SIZE + 1];  /* full path to interpreter''s directory */

/*** Variables -- Mac Related ***/
MenuHandle		appleMenu = nil;
Handle			clipboardBuffer = nil;
MenuHandle		editMenu = nil;
MenuHandle		fileMenu = nil;
CTabHandle		stColorTable = nil;
PixMapHandle	stPixMap = nil;
WindowPtr		stWindow = nil;

/*** Variables -- Event Recording ***/
#define KEYBUF_SIZE 64
int keyBuf[KEYBUF_SIZE];	/* circular buffer */
int keyBufGet = 0;			/* index of next item of keyBuf to read */
int keyBufPut = 0;			/* index of next item of keyBuf to write */
int keyBufOverflows = 0;	/* number of characters dropped */

int buttonState = 0;		/* mouse button and modifier state when mouse
							   button went down or 0 if not pressed */

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
void SetColorEntry(int index, int red, int green, int blue);
void SetUpClipboard(void);
void SetUpMenus(void);
void SetUpPixmap(void);
void SetUpWindow(void);
void SetWindowTitle(char *title);
void StoreFullPathForLocalNameInto(char *shortName, char *fullName, int length);

/* event capture */
int recordKeystroke(EventRecord *theEvent);
int recordModifierButtons(EventRecord *theEvent);
int recordMouseDown(EventRecord *theEvent);

/*** Apple Event Handlers ***/
static pascal OSErr HandleOpenAppEvent(AEDescList *aevt, AEDescList *reply, int refCon);
static pascal OSErr HandleOpenDocEvent(AEDescList *aevt, AEDescList *reply, int refCon);
static pascal OSErr HandlePrintDocEvent(AEDescList *aevt, AEDescList *reply, int refCon);
static pascal OSErr HandleQuitAppEvent(AEDescList *aevt, AEDescList *reply, int refCon);

/*** Apple Event Handling ***/

void InstallAppleEventHandlers() {
	OSErr	err;
	long	result;

	shortImageName[0] = 0;
	err = Gestalt(gestaltAppleEventsAttr, &result);
	if (err == noErr) {
		AEInstallEventHandler(kCoreEventClass, kAEOpenApplication, NewAEEventHandlerProc(HandleOpenAppEvent),  0, false);
		AEInstallEventHandler(kCoreEventClass, kAEOpenDocuments,   NewAEEventHandlerProc(HandleOpenDocEvent),  0, false);
		AEInstallEventHandler(kCoreEventClass, kAEPrintDocuments,  NewAEEventHandlerProc(HandlePrintDocEvent), 0, false);
		AEInstallEventHandler(kCoreEventClass, kAEQuitApplication, NewAEEventHandlerProc(HandleQuitAppEvent),  0, false);
	}
}

pascal OSErr HandleOpenAppEvent(AEDescList *aevt, AEDescList *reply, int refCon) {
	/* User double-clicked application; look for "squeak.image" in same directory */

	aevt; reply; refCon;  /* reference args to avoid compiler warnings */

	/* record path to VM''s home folder */
	dir_PathToWorkingDir(vmPath, VMPATH_SIZE);

	/* use default image name in same directory as the VM */
	strcpy(shortImageName, "squeak.image");
	return noErr;
}

pascal OSErr HandleOpenDocEvent(AEDescList *aevt, AEDescList *reply, int refCon) {
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

	reply; refCon;  /* reference args to avoid compiler warnings */

	/* record path to VM''s home folder */
	dir_PathToWorkingDir(vmPath, VMPATH_SIZE);

	/* copy document list */
	err = AEGetKeyDesc(aevt, keyDirectObject, typeAEList, &fileList);
	if (err) goto done;

	/* count list elements */
	err = AECountItems( &fileList, &numFiles);
	if (err) goto done;
	if (numFiles != 1) {
		error("You may only open one Squeak image or document file at a time.");
	}

	/* get image name */
	err = AEGetNthPtr(&fileList, 1, typeFSS,
					  &keyword, &type, (Ptr) &fileSpec, sizeof(fileSpec), &size);
	if (err) goto done;
	strcpy(shortImageName, p2cstr(fileSpec.name));

	if (!IsImageName(shortImageName)) {
		/* record the document name, but run the default image in VM directory */
		strcpy(shortDocumentName, shortImageName);
		strcpy(shortImageName, "squeak.image");
		StoreFullPathForLocalNameInto(shortImageName, imageName, IMAGE_NAME_SIZE);
	}
	/* make the image or document directory the working directory */
	pb.ioNamePtr = NULL;
	pb.ioVRefNum = fileSpec.vRefNum;
	pb.ioWDDirID = fileSpec.parID;
	PBHSetVolSync(&pb);

	if (shortDocumentName[0] != 0) {
		/* record the document''s full name */
		StoreFullPathForLocalNameInto(shortDocumentName, documentName, DOCUMENT_NAME_SIZE);
	}

done:
	AEDisposeDesc(&fileList);
	return err;
}

pascal OSErr HandlePrintDocEvent(AEDescList *aevt, AEDescList *reply, int refCon) {
	aevt; reply; refCon;  /* reference args to avoid compiler warnings */
	return errAEEventNotHandled;
}

pascal OSErr HandleQuitAppEvent(AEDescList *aevt, AEDescList *reply, int refCon) {
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
	WindowPeek		wp;
	int				isDeskAccessory;

	wp = (WindowPeek) FrontWindow();
	if (wp != NULL) {
		isDeskAccessory = (wp->windowKind < 0);
	} else {
		isDeskAccessory = false;
	}

	if (isDeskAccessory) {
		/* Enable items in the Edit menu */
		EnableItem(editMenu, 1);
		EnableItem(editMenu, 3);
		EnableItem(editMenu, 4);
		EnableItem(editMenu, 5);
		EnableItem(editMenu, 6);
	} else {
		/* Disable items in the Edit menu */
		DisableItem(editMenu, 1);
		DisableItem(editMenu, 3);
		DisableItem(editMenu, 4);
		DisableItem(editMenu, 5);
		DisableItem(editMenu, 6);
	}
}

int HandleEvents(void) {
	EventRecord		theEvent;
	int				ok;

	SystemTask();
	ok = GetNextEvent(everyEvent, &theEvent);
	if (ok) {
		switch (theEvent.what) {
			case mouseDown:
				HandleMouseDown(&theEvent);
				return false;
			break;

			case mouseUp:
				recordModifierButtons(&theEvent);
				return false;
			break;

			case keyDown:
			case autoKey:
				if ((theEvent.modifiers & cmdKey) != 0) {
					AdjustMenus();
					HandleMenu(MenuKey(theEvent.message & charCodeMask));
				}
				recordModifierButtons(&theEvent);
				recordKeystroke(&theEvent);
			break;

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
				InvalRect(&stWindow->portRect);
			break;

			case kHighLevelEvent:
				AEProcessAppleEvent(&theEvent);
			break;
		}
	}
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
			OpenDeskAcc(name);
			SetPort(savePort);
		break;

		case fileID:
			if (menuItem == quitItem) {
				ioExit();
			}
		break;

		case editID:
			if (!SystemEdit(menuItem - 1)) {
				SysBeep(5);
			}
		break;
	}
}

void HandleMouseDown(EventRecord *theEvent) {
	WindowPtr	theWindow;
	Rect		growLimits = { 20, 20, 4000, 4000 };
	Rect		dragBounds;
	int			windowCode, newSize;

	windowCode = FindWindow(theEvent->where, &theWindow);
	switch (windowCode) {
		case inSysWindow:
			SystemClick(theEvent, theWindow);
		break;

		case inMenuBar:
			AdjustMenus();
			HandleMenu(MenuSelect(theEvent->where));
		break;

		case inDrag:
			dragBounds = qd.screenBits.bounds;
			if (theWindow == stWindow) {
				DragWindow(stWindow, theEvent->where, &dragBounds);
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
				recordMouseDown(theEvent);
			}
		break;

		case inGoAway:
			if ((theWindow == stWindow) &&
				(TrackGoAway(stWindow, theEvent->where))) {
					/* HideWindow(stWindow); noop for now */
			}
		break;
	}
}

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

void SetUpMenus(void) {
	InsertMenu(appleMenu = NewMenu(appleID, "\p\024"), 0);
	InsertMenu(fileMenu  = NewMenu(fileID,  "\pFile"), 0);
	InsertMenu(editMenu  = NewMenu(editID,  "\pEdit"), 0);
	DrawMenuBar();
	AppendResMenu(appleMenu, ''DRVR'');
	AppendMenu(fileMenu, "\pQuit");
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

	stWindow = NewCWindow(
		0L, &windowBounds,
		"\p Welcome to Squeak!  Reading Squeak image file... ",
		true, documentProc, (WindowPtr) -1L, true, 0);
}

void SetWindowTitle(char *title) {
	SetWTitle(stWindow, c2pstr(title));
	p2cstr((unsigned char *) title);
}

/*** Event Recording Functions ***/

int recordKeystroke(EventRecord *theEvent) {
	int keystate;

	/* keystate: low byte is the ascii character; next 4 bits are modifier bits */
	keystate =
		(modifierMap[(theEvent->modifiers >> 8) & 0x1F] << 8) |
		(theEvent->message & 0xFF);
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
	int stButtons;

	stButtons = 4;		/* red button by default */
	if ((theEvent->modifiers & optionKey) != 0) {
		stButtons = 2;	/* yellow button if option down */
	}
	if ((theEvent->modifiers & cmdKey) != 0) {
		stButtons = 1;	/* blue button if command down */
	}
	/* button state: low three bits are mouse buttons; next 4 bits are modifier bits */
	buttonState =
		(modifierMap[(theEvent->modifiers >> 8) & 0x1F] << 3) |
		(stButtons & 0x7);
}

int recordModifierButtons(EventRecord *theEvent) {
	int stButtons = 0;

	if (Button()) {
		stButtons = buttonState & 0x7;
	} else {
		stButtons = 0;
	}
	/* button state: low three bits are mouse buttons; next 4 bits are modifier bits */
	buttonState =
		(modifierMap[(theEvent->modifiers >> 8) & 0x1F] << 3) |
		(stButtons & 0x7);
}

/*** I/O Primitives ***/

int ioBeep(void) {
	SysBeep(1000);
}

int ioExit(void) {
	sqNetworkShutdown();
	ExitToShell();
}

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

int ioMicroMSecs(void) {
	/* millisecond clock based on microsecond timer (about 60 times slower than clock()!!) */
	/* Note: This function and ioMSecs() both return a time in milliseconds. The difference
	   is that ioMicroMSecs() is called only when precise millisecond resolution is essential,
	   and thus it can use a more expensive timer than ioMSecs, which is called frequently.
	   However, later VM optimizations reduced the frequency of calls to ioMSecs to the point
	   where clock performance became less critical, and we also started to want millisecond-
	   resolution timers for real time applications such as music. Thus, on the Mac, we''ve
	   opted to use the microsecond clock for both ioMSecs() and ioMicroMSecs(). */
	UnsignedWide microTicks;

	Microseconds(&microTicks);
	return (microTicks.lo / 1000) + (microTicks.hi * 4294967);
}

int ioMSecs(void) {
	/* return a time in milliseconds for use in Delays and Time millisecondClockValue */
	/* Note: This was once a macro based on clock(); it now uses the microsecond clock for
	   greater resolution. See the comment in ioMicroMSecs(). */
	UnsignedWide microTicks;

	Microseconds(&microTicks);
	return (microTicks.lo / 1000) + (microTicks.hi * 4294967);
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
	int maxPollsPerSec = 30;
	static clock_t nextPollTick = 0;

#ifndef PLUGIN
	if (clock() > nextPollTick) {
		/* time to process events! */
		while (HandleEvents()) {
			/* process all pending events */
		}

		/* wait a while before trying again */
		nextPollTick = clock() + (CLOCKS_PER_SEC / maxPollsPerSec);
	}
#endif
	return interruptPending;
}

int ioRelinquishProcessorForMicroseconds(int microSeconds) {
	/* This operation is platform dependent. On the Mac, it simply calls
	 * HandleEvents(), which gives other applications a chance to run.
	 */

	while (HandleEvents()) {
		/* process all pending events */
	}
	return microSeconds;
}

int ioScreenSize(void) {
	int w = 10, h = 10;

	if (stWindow != nil) {
		w = stWindow->portRect.right - stWindow->portRect.left;
		h = stWindow->portRect.bottom - stWindow->portRect.top;
	}
	return (w << 16) | (h & 0xFFFF);  /* w is high 16 bits; h is low 16 bits */
}

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
	Cursor macCursor;
	int i;

	for (i = 0; i < 16; i++) {
		macCursor.data[i] = (checkedLongAt(cursorBitsIndex + (4 * i)) >> 16) & 0xFFFF;
		macCursor.mask[i] = (checkedLongAt(cursorBitsIndex + (4 * i)) >> 16) & 0xFFFF;
	}

	/* Squeak hotspot offsets are negative; Mac''s are positive */
	macCursor.hotSpot.h = -offsetX;
	macCursor.hotSpot.v = -offsetY;
	SetCursor(&macCursor);
}

int ioSetFullScreen(int fullScreen) {
	Rect screen = qd.screenBits.bounds;
	int width, height, maxWidth, maxHeight;
	int oldWidth, oldHeight;

	if (fullScreen) {
		oldWidth = stWindow->portRect.right - stWindow->portRect.left;
		oldHeight = stWindow->portRect.bottom - stWindow->portRect.top;
		width  = screen.right - screen.left;
		height = (screen.bottom - screen.top) - 20;
		if ((oldWidth < width) || (oldHeight < height)) {
			/* save old size if it wasn''t already full-screen */ 
			savedWindowSize = (oldWidth << 16) + (oldHeight & 0xFFFF);
		}
		MoveWindow(stWindow, 0, 20, true);
		SizeWindow(stWindow, width, height, true);
		fullScreenFlag = true;
	} else {
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
	(*stPixMap)->cmpSize = depth;

	/* create a mask region so that only the affected rectangle is copied */
	maskRect = NewRgn();
	SetRectRgn(maskRect, affectedL, affectedT, affectedR, affectedB);

	SetPort(stWindow);
	CopyBits((BitMap *) *stPixMap, &stWindow->portBits, &srcRect, &dstRect, srcCopy, maskRect);
	DisposeRgn(maskRect);
}

/*** Image File Naming ***/

void StoreFullPathForLocalNameInto(char *shortName, char *fullName, int length) {
	int offset, sz, i;

	offset = dir_PathToWorkingDir(fullName, length);

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

/*** Clipboard Support (text only for now) ***/

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

	srcPtr = (char *) *clipboardBuffer;
	dstPtr = (char *) byteArrayIndex + startIndex;
	end = srcPtr + charsToMove;
	while (srcPtr < end) {
		*dstPtr++ = *srcPtr++;
	}
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
	if (memory == nil) {
		return;	/* failed to read image */
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

	strcpy(imageName, fullImagePath);
	dir_PathToWorkingDir(vmPath, VMPATH_SIZE);

	SetUpClipboard();
	SetUpPixmap();
	sqFileInit();
	joystickInit();
}

int plugInShutdown(void) {
	snd_Stop();
	FreeClipboard();
	FreePixmap();
	if (memory != nil) {
		DisposePtr((void *) memory);
		memory = nil;
	}
}

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
	// id #1 should return imageName, but returns empty string in this release to
	// ease the transition (1.3x images otherwise try to read image as a document)
	if (id == 1) return "";  /* will be imageName */
	if (id == 2) return documentName;

	if (id == 1001) return "Mac OS";
	if (id == 1002) return "System 7 or Later";
	if (id == 1003) return "PowerPC or 680xx";

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
	unsigned char *pascalFileName;

	pascalFileName = c2pstr(fileName);
	err = FSOpen(pascalFileName, 0, &fRefNum);
	if ((err != 0) && (strchr(mode, ''w'') != null)) {
		/* creating a new file for "save as" */
		err2 = Create(pascalFileName, 0, ''FAST'', ''STim'');
		if (err2 == 0) {
			err = FSOpen(pascalFileName, 0, &fRefNum);
		}
	}
	p2cstr(pascalFileName);
	if (err != 0) return null;

	if (strchr(mode, ''w'') != null) {
		/* truncate file if opening in write mode */
		err = SetEOF(fRefNum, 0);
		if (err != 0) {
			FSClose(fRefNum);
			return null;
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

/*** Main ***/

#ifndef PLUGIN
void main(void) {
	EventRecord theEvent;
	sqImageFile f;
	int reservedMemory, availableMemory;

	InitMacintosh();
	SetUpMenus();
	SetUpClipboard();
	SetUpWindow();
	SetUpPixmap();
	sqFileInit();
	joystickInit();

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
		StoreFullPathForLocalNameInto(shortImageName, imageName, IMAGE_NAME_SIZE);
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
	reservedMemory = 400000;
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
	    preloaded unless there is about 100K reserved. Added 30K to that.)
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
	readImageFromFileHeapSize(f, availableMemory);
	sqImageFileClose(f);

	SetWindowTitle(shortImageName);
	ioSetFullScreen(fullScreenFlag);

	/* run Squeak */
	interpret();
}
#endif
'
.
