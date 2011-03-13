macBrowserPluginFile

	^ '/********** Notes on Browser Plugin VM ************
How it Works:

The browser plugin VM allows Squeak to be run as a plug-in under
version 4.0 and later of either Netscape Navigator or Internet Explorer.
To use it, you must translate a version of interp.c with the browser plugin
hooks. These hooks work by causing the VM to save the state of the current
Squeak process and return control from the interpret() after a short
period of time (e.g., 1/10th second or 1/60th). This allows the browser to process
events and perform other tasks. Eventually, the browser calls NPP_HandleEvent()
with a NULL event, thus re-entering the Squeak interpret loop. The key to
efficiency is to not return control to the browser too often, since the
browser is quite slow to send the next null event. The VM does this
by polling for events itself; if there are no events in the OS queue,
then it return control to the browser much less often.

Note for fullscreen support NPP_HandleEvent does not return control, it consumes 
events from waitnextevent. When fullscreen mode is turn off then control is 
returned to the browser.

Relationship of this file to sqMacWindow.c:

One can think of this file as specializing and extending sqMacWindow.c
for running within a browser. Certain methods in  sqMacWindow.c are
replaced by functions defined here. The originals are removed from
sqMacWindow.c by defining the PLUGIN flag in that file when compiling.
Here is a list of the functions overridden:

	ioExit()
	ioScreenSize()
	ioSetFullScreen()
	sqAllocateMemory()
    plugInAllowAccessToFilePath()

In addition, ioProcessEvents() becomes a noop and main() is completely
omitted when sqMacWindow.c is compiled for use in the browser plugin VM.

 Thing busted 2000 July 26th
 squeak quit restart has issues with change file open
 

June/July 2000 johnmci@smalltalkconsulting.com Reviewed code readded comments, added FullScreen Support
				fixed issues with Carbon, general code cleaning.

Sept 27th 2000 johnmci@smalltalkconsulting.com added logic to have more flexibility in memory size.
				Fix issue with volume ID, don''t use 0
				Fix issue were IE lies about the frame size as it figures out the frame size in real time durning rendering
				Added check for file: in URL logic to disallow
				Fixed problem in NPP_URLNotify, must call notify complete logic
				Ensure NP_memFree is called for plugin arguments
				Add logic for URLPosting
**********/

#include "sq.h"
#include "FilePlugin.h"
#include "npapi.h"

#include <Events.h>
#include <Files.h>
#include <Notification.h>
#include <Strings.h>
#include <MacWindows.h>
#include <Movies.h>
#include <Folders.h>
#include <string.h>
#include <ctype.h>

#if TARGET_API_MAC_CARBON
    #define EnableMenuItemCarbon(m1,v1)  EnableMenuItem(m1,v1);
    #define DisableMenuItemCarbon(m1,v1)  DisableMenuItem(m1,v1);
#else
    #define EnableMenuItemCarbon(m1,v1)  EnableItem(m1,v1);
    #define DisableMenuItemCarbon(m1,v1)  DisableItem(m1,v1);
        inline Rect *GetPortBounds(CGrafPtr w,Rect *r) { *r = w->portRect; return &w->portRect;}  
        inline Rect *GetRegionBounds(RgnHandle region, Rect * bounds) { *bounds = (*region)->rgnBBox; return &(*region)->rgnBBox;}
        inline RgnHandle GetPortClipRegion(CGrafPtr port,RgnHandle clipRgn) {MacCopyRgn (port->clipRgn,clipRgn); return clipRgn;}  
        inline BitMap *GetQDGlobalsScreenBits(BitMap *bm){*bm = qd.screenBits; return &qd.screenBits; }
        inline BitMap * GetPortBitMapForCopyBits (CGrafPtr w) { return &((GrafPtr)w)->portBits;}
        inline pascal long InvalWindowRect(WindowRef  window,  const Rect * bounds) {InvalRect (bounds);}
#endif


/********** Compilation Options:
*
*	ENABLE_URL_FETCH
*	  Define this to compile primitives to fetch URL''s via the browser.
*
*	  Warning: Fetching file URL''s through the URL fetch mechanism allows
*	  potentially untrusted code to read files outside of the Squeak
*	  file system "sandbox", a serious breach of privacy. 
*	  There are few uses for use for the browser URL fetch
*	  mechanism, since you can always fetch URL''s from remote servers
*	  using Squeak''s own HTTPSocket.
*
**********/

#define ENABLE_URL_FETCH  
#define IMAGE_NAME "SqueakPlugin.image"
#define VMPATH_SIZE 300

/*** Exported Primitives ***/

#ifdef ENABLE_URL_FETCH
#pragma export on
int primitivePluginBrowserReady(void);
int primitivePluginDestroyRequest(void);
int primitivePluginRequestFileHandle(void);
int primitivePluginRequestState(void);
int primitivePluginRequestURL(void);
int primitivePluginRequestURLStream(void);
int primitivePluginPostURL(void);
#pragma export off
#endif

/* Constants */

#define MAX_STRING_LENGTH 255
#define MAX_ARG_STRING_LENGTH 100
#define STATUS_BAD_HANDLE -1
#define STATUS_IDLE 0
#define STATUS_IN_PROGRESS 1
#define STATUS_FAILED 2
#define STATUS_SUCCEEDED 3
#define STARTINGsqueakHeapMBytes 20*1024*1024

/*** Imported Variables ***/

extern int interruptKeycode;
extern unsigned char *memory;
extern WindowPtr stWindow;
extern int fullScreenFlag;

extern char documentName[];  /* full path to document file */
extern char imageName[];  /* full path to image file */
extern char shortImageName[];  /* just the image file name */
extern char vmPath[];  /* full path to interpreter''s directory */

extern struct VirtualMachine *interpreterProxy;

extern int thisSession;  /* from sqFilePrims.c: */

/*** Local Variables ***/

int			exitRequested	= false;
Rect    	gSavePortPortRect;
RgnHandle   gSavePortClipRgn;
CGrafPtr	gOldPort		= nil;
int			interpStartTime	= 0;
int			needsUpdate		= false;
NPWindow* 	netscapeWindow	= nil;
Str255		notificationMsg = "";
NMRec		notifyRec;
int			pluginArgCount	= 0;
char		*pluginArgName[MAX_ARG_STRING_LENGTH];
char		*pluginArgValue[MAX_ARG_STRING_LENGTH];
Boolean     ignoreFirstEvent=false;
int			squeakHeapMBytes = STARTINGsqueakHeapMBytes;  /* default heap size, override via the "memory" EMBED tag */
char		squeakPluginImageName[] = IMAGE_NAME;
NPP			thisInstance	= nil;
WindowPtr gAFullscreenWindow = nil;
char        rememberMemoryString[128]="";


#define URL_REQUEST_COUNT 100

typedef struct {
	int id;  /* used to associate a request with its outcome */
	int status;
	int semaIndex;
	char fileName[MAX_STRING_LENGTH + 1];
	char *buffer;
} URLRequestRecord;

URLRequestRecord urlRequests[URL_REQUEST_COUNT];
int nextRequestID = 1;

/*** Functions Imported from sqMacWindow ***/

int recordKeystroke(EventRecord *theEvent);
int recordModifierButtons(EventRecord *theEvent);
int recordMouseDown(EventRecord *theEvent);
void ioSetFullScreenRestore();
int PrefixPathWith(char *pathName, int pathNameSize, int pathNameMax, char *prefix);

/*** From VM ***/
int checkImageVersionFromstartingAt(sqImageFile f, int imageOffset);
int getLongFromFileswap(sqImageFile f, int swapFlag);


/*** Local Functions ***/

int  CaseInsensitiveMatch(char *s1, char *s2);
void EndDraw(void);
void ExitCleanup(void);
int  FindIdleURLRequest(void);
int  InitFilePaths(void);
void InitURLRequestTable(void);
int  IsPrefixedBy(char *s, char *prefix);
void OpenFileReadOnly(SQFile *f, char *fileName);
void ReadSqueakImage(void);
void StartDraw(void);
int  StringToInteger(char *s);
int PathToPreferenceDir(char *pathName, long pathNameMax, long volumeID, long directoryID);
void URLRequestCompleted(int notifyData, const char* fileName);
int  URLRequestCreate(char *url, char *target, int semaIndex);
void URLRequestDestroy(int requestHandle);
void URLRequestFailed(int notifyData, int reason);
char * URLRequestFileName(int requestHandle);
int  URLRequestStatus(int requestHandle);
int parseMemorySize(int baseSize, char *src);
int AbortIfFileURL(char *url);
int URLPostCreate(char *url, char *buffer, char * window,int semaIndex);

/*** Initialize/Shutdown ***/

/*+++++++++++++++++++++++++++++++++++++++++++++++++
 * NPP_Initialize:
 * Provides global initialization for a plug-in, and returns an error value. 
 *
 * This function is called once when a plug-in is loaded, before the first instance
 * is created. Allocate any memory or resources shared by all
 * instances of your plug-in at this time. After the last instance has been deleted,
 * NPP_Shutdown will be called, where you can release any memory or
 * resources allocated by NPP_Initialize. 
 +++++++++++++++++++++++++++++++++++++++++++++++++*/
NPError NPP_Initialize(void) {
	exitRequested = false;
	needsUpdate = false;
	netscapeWindow = nil;
	pluginArgCount = 0;
	thisInstance = nil;
	InitURLRequestTable();
	return NPERR_NO_ERROR;
}

/*+++++++++++++++++++++++++++++++++++++++++++++++++
 * NPP_GetJavaClass:
 * New in Netscape Navigator 3.0. 
 *
 * NPP_GetJavaClass is called during initialization to ask your plugin
 * what its associated Java class is. If you don''t have one, just return
 * NULL. 
 +++++++++++++++++++++++++++++++++++++++++++++++++*/
jref
NPP_GetJavaClass(void)
{
	return (jref) NULL;
}

/*+++++++++++++++++++++++++++++++++++++++++++++++++
 * NPP_Shutdown:
 * Provides global deinitialization for a plug-in. 
 * 
 * This function is called once after the last instance of your plug-in is destroyed.
 * Use this function to release any memory or resources shared across all
 * instances of your plug-in. 
 +++++++++++++++++++++++++++++++++++++++++++++++++*/

void NPP_Shutdown(void) {
	ExitCleanup();
}

/*** Instance Create/Destroy ***/
/*+++++++++++++++++++++++++++++++++++++++++++++++++
 * NPP_New:
 * Creates a new instance of a plug-in and returns an error value. 
 * 
 * NPP_New creates a new instance of your plug-in with MIME type specified
 * by pluginType. The parameter mode is NP_EMBED if the instance was created
 * by an EMBED tag, or NP_FULL if the instance was created by a separate file.
 * You can allocate any instance-specific private data in instance->pdata at this
 * time. The NPP pointer is valid until the instance is destroyed. 
 +++++++++++++++++++++++++++++++++++++++++++++++++*/

NPError NPP_New(NPMIMEType pluginType, NPP instance, uint16 mode,
  int16 argc, char* argn[], char* argv[], NPSavedData* saved) {
	int i;

	/* only one Squeak instance can be active at a time */
	if (thisInstance != nil) return NPERR_GENERIC_ERROR;

	for (i = 0; i < MAX_ARG_STRING_LENGTH; i++) {
		pluginArgName[i] = pluginArgValue[i] = "";
	}

	/* record plugin arguments */
	pluginArgCount = argc;
	for (i = 0; (i < argc) && (i < MAX_ARG_STRING_LENGTH); i++) {
		pluginArgName[i] = (char *) NPN_MemAlloc(strlen(argn[i]) + 1);
		strcpy(pluginArgName[i], argn[i]);
		pluginArgValue[i] = (char *) NPN_MemAlloc(strlen(argv[i]) + 1);
		strcpy(pluginArgValue[i], argv[i]);
		if (CaseInsensitiveMatch(pluginArgName[i], "memory")) {
			strcpy(rememberMemoryString,pluginArgValue[i]);
		}
	}

	memory = nil;
	ReadSqueakImage();
	if (!memory) return NPERR_GENERIC_ERROR;

	thisInstance = instance;
	return NPERR_NO_ERROR;
}

/*+++++++++++++++++++++++++++++++++++++++++++++++++
 * NPP_Destroy:
 * Deletes a specific instance of a plug-in and returns an error value. 

 * NPP_Destroy is called when a plug-in instance is deleted, typically because the
 * user has left the page containing the instance, closed the window, or quit the
 * application. You should delete any private instance-specific information stored
 * in instance->pdata. If the instance being deleted is the last instance created
 * by your plug-in, NPP_Shutdown will subsequently be called, where you can
 * delete any data allocated in NPP_Initialize to be shared by all your plug-in''s
 * instances. Note that you should not perform any graphics operations in
 * NPP_Destroy as the instance''s window is no longer guaranteed to be valid. 
 +++++++++++++++++++++++++++++++++++++++++++++++++*/
NPError NPP_Destroy(NPP instance, NPSavedData** save) {
	long i;
	
	ExitCleanup();
	if (pluginArgCount != 0) {
		for(i=0;i<pluginArgCount;i++) {
			NPN_MemFree(pluginArgName[i]);
			NPN_MemFree(pluginArgValue[i]);
		}
		pluginArgCount = 0;
	}
	return NPERR_NO_ERROR;
}

/*+++++++++++++++++++++++++++++++++++++++++++++++++
 * NPP_SetWindow:
 * Sets the window in which a plug-in draws, and returns an error value. 
 * 
 * NPP_SetWindow informs the plug-in instance specified by instance of the
 * the window denoted by window in which the instance draws. This NPWindow
 * pointer is valid for the life of the instance, or until NPP_SetWindow is called
 * again with a different value. Subsequent calls to NPP_SetWindow for a given
 * instance typically indicate that the window has been resized. If either window
 * or window->window are NULL, the plug-in must not perform any additional
 * graphics operations on the window and should free any resources associated
 * with the window. 
 +++++++++++++++++++++++++++++++++++++++++++++++++*/
NPError NPP_SetWindow(NPP instance, NPWindow* window) {
	NP_Port* port;

	if (window == NULL) return NPERR_NO_ERROR;
	if (window->window == NULL) return NPERR_NO_ERROR;
	
	netscapeWindow = window;
	port = (NP_Port *) netscapeWindow->window;
	stWindow = (WindowPtr) port->port;
	needsUpdate	= true;
	return NPERR_NO_ERROR;
}

/*** Streaming ***/

/*+++++++++++++++++++++++++++++++++++++++++++++++++
 * NPP_NewStream:
 * Notifies an instance of a new data stream and returns an error value. 
 * 
 * NPP_NewStream notifies the instance denoted by instance of the creation of
 * a new stream specifed by stream. The NPStream* pointer is valid until the
 * stream is destroyed. The MIME type of the stream is provided by the
 * parameter type. 
 +++++++++++++++++++++++++++++++++++++++++++++++++*/
NPError NPP_NewStream(
  NPP instance, NPMIMEType type,
  NPStream *stream, NPBool seekable, uint16 *stype) {
  /* Call to load the initial URL and to handle explicit URL fetch requests. */

	*stype = NP_ASFILEONLY;  /* ask Netscape to cache file and call NPP_StreamAsFile */
	return NPERR_NO_ERROR;
}

/*+++++++++++++++++++++++++++++++++++++++++++++++++
 * NPP_DestroyStream:
 * Indicates the closure and deletion of a stream, and returns an error value. 
 * 
 * The NPP_DestroyStream function is called when the stream identified by
 * stream for the plug-in instance denoted by instance will be destroyed. You
 * should delete any private data allocated in stream->pdata at this time. 
 +++++++++++++++++++++++++++++++++++++++++++++++++*/
NPError NPP_DestroyStream(NPP instance, NPStream *stream, NPError reason) {
	return NPERR_NO_ERROR;
}

/*+++++++++++++++++++++++++++++++++++++++++++++++++
 * NPP_StreamAsFile:
 * Provides a local file name for the data from a stream. 
 * 
 * NPP_StreamAsFile provides the instance with a full path to a local file,
 * identified by fname, for the stream specified by stream. NPP_StreamAsFile is
 * called as a result of the plug-in requesting mode NP_ASFILEONLY or
 * NP_ASFILE in a previous call to NPP_NewStream. If an error occurs while
 * retrieving the data or writing the file, fname may be NULL. 
 +++++++++++++++++++++++++++++++++++++++++++++++++*/
void NPP_StreamAsFile(NPP instance, NPStream *stream, const char* fname) {
	if (fname != null) 
		URLRequestCompleted((int) stream->notifyData, fname);
	 else 
		URLRequestFailed((int) stream->notifyData, 1);
}


/*+++++++++++++++++++++++++++++++++++++++++++++++++
 * NPP_WriteReady:
 * Returns the maximum number of bytes that an instance is prepared to accept
 * from the stream. 
 * 
 * NPP_WriteReady determines the maximum number of bytes that the
 * instance will consume from the stream in a subsequent call NPP_Write. This
 * function allows Netscape to only send as much data to the instance as the
 * instance is capable of handling at a time, allowing more efficient use of
 * resources within both Netscape and the plug-in. 
 +++++++++++++++++++++++++++++++++++++++++++++++++*/
int32 NPP_WriteReady(NPP instance, NPStream *stream) {
  /* not used, because we use ASFILEONLY mode */

	return 100000;
}

/*+++++++++++++++++++++++++++++++++++++++++++++++++
 * NPP_Write:
 * Delivers data from a stream and returns the number of bytes written. 
 * 
 * NPP_Write is called after a call to NPP_NewStream in which the plug-in
 * requested a normal-mode stream, in which the data in the stream is delivered
 * progressively over a series of calls to NPP_WriteReady and NPP_Write. The
 * function delivers a buffer buf of len bytes of data from the stream identified
 * by stream to the instance. The parameter offset is the logical position of
 * buf from the beginning of the data in the stream. 
 * 
 * The function returns the number of bytes written (consumed by the instance).
 * A negative return value causes an error on the stream, which will
 * subsequently be destroyed via a call to NPP_DestroyStream. 
 * 
 * Note that a plug-in must consume at least as many bytes as it indicated in the
 * preceeding NPP_WriteReady call. All data consumed must be either processed
 * immediately or copied to memory allocated by the plug-in: the buf parameter
 * is not persistent. 
 +++++++++++++++++++++++++++++++++++++++++++++++++*/
int32 NPP_Write(NPP instance, NPStream *stream, int32 offset, int32 len, void *buffer) {
  /* not used, because we use ASFILEONLY mode */

	return len;
}

/*+++++++++++++++++++++++++++++++++++++++++++++++++
 * NPP_URLNotify:
 * Notifies the instance of the completion of a URL request. 
 * 
 * NPP_URLNotify is called when Netscape completes a NPN_GetURLNotify or
 * NPN_PostURLNotify request, to inform the plug-in that the request,
 * identified by url, has completed for the reason specified by reason. The most
 * common reason code is NPRES_DONE, indicating simply that the request
 * completed normally. Other possible reason codes are NPRES_USER_BREAK,
 * indicating that the request was halted due to a user action (for example,
 * clicking the "Stop" button), and NPRES_NETWORK_ERR, indicating that the
 * request could not be completed (for example, because the URL could not be
 * found). The complete list of reason codes is found in npapi.h. 
 * 
 * The parameter notifyData is the same plug-in-private value passed as an
 * argument to the corresponding NPN_GetURLNotify or NPN_PostURLNotify
 * call, and can be used by your plug-in to uniquely identify the request. 
 +++++++++++++++++++++++++++++++++++++++++++++++++*/
void NPP_URLNotify(NPP instance, const char* url, NPReason reason, void* notifyData) {
	if (reason != NPRES_DONE) 
		URLRequestFailed((int) notifyData, reason);
	else
		URLRequestCompleted((int) notifyData, null);

}

/*** Printing ***/

void NPP_Print(NPP instance, NPPrint* printInfo) {
	/* printing is not supported */
}

/*** Event Handling ***/

/*+++++++++++++++++++++++++++++++++++++++++++++++++
 * NPP_HandleEvent:
 * Mac-only, but stub must be present for Windows
 * Delivers a platform-specific event to the instance. 
 * 
 * On the Macintosh, event is a pointer to a standard Macintosh EventRecord.
 * All standard event types are passed to the instance as appropriate. In general,
 * return TRUE if you handle the event and FALSE if you ignore the event. 
 * Note special logic for full screen support
 +++++++++++++++++++++++++++++++++++++++++++++++++*/

int16 NPP_HandleEvent(NPP instance, void *rawEvent) {
	EventRecord *eventPtr = (EventRecord*) rawEvent;
	EventRecord	theEvent;
	int				ok;

	do {
	
    	if (exitRequested) {
    		exitRequested = false;
    		ExitCleanup();
    		return false;
    	}

    	if ((thisInstance == nil) || (eventPtr == NULL)) {
    		/* no instance or no event; do nothing */
    		return false;
    	}

    	recordModifierButtons(eventPtr);
    	switch (eventPtr->what) {
    		case mouseDown:
    			recordMouseDown(eventPtr);
    		break;

    		case keyDown:
    		case autoKey:
    			recordKeystroke(eventPtr);
    		break;

    		case updateEvt:
    			needsUpdate = true;
    		break;
    		
    		case nullEvent:
    			/* interpret some bytecodes on every event */
    			if (memory) {  /* but only if the VM has memory! */
    				StartDraw();
    				interpret();
    				EndDraw();
    			}
    		break;
    	}

    	if (needsUpdate && (netscapeWindow != nil) && (memory)) {
    		if (fullScreenFlag) {
    		    BeginUpdate((WindowPtr) eventPtr->message);
     		}
    		StartDraw();
    		fullDisplayUpdate();  /* ask VM to call ioShowDisplay */
    		EndDraw();
    		if (fullScreenFlag) {
    		    EndUpdate((WindowPtr) eventPtr->message);
   			}
    		needsUpdate = false;
    	}
    	if (ignoreFirstEvent  &&  fullScreenFlag) {
    	    ignoreFirstEvent = false;
    	    return true;
    	}
    	if (fullScreenFlag) {
     	    ok = WaitNextEvent(everyEvent, &theEvent,0,null);
            eventPtr = &theEvent;
    	}
	} while (fullScreenFlag);
	return true;
}

/*** Drawing ***/

void EndDraw(void) {
	SetOrigin(gSavePortPortRect.left, gSavePortPortRect.top);
	SetClip(gSavePortClipRgn);
	SetPort((GrafPtr) gOldPort);
}

void StartDraw(void) {
	NP_Port* port;
	Rect clipRect;
	

	port = (NP_Port *) netscapeWindow->window;

	/* save old graphics port and switch to ours */
	GetPort((GrafPtr *) &gOldPort);
	SetPort((GrafPtr) port->port);
	stWindow = (WindowPtr) port->port;

	/* save old drawing environment */
	GetPortBounds(port->port,&gSavePortPortRect);
	GetClip(gSavePortClipRgn);

	/* setup our drawing environment */
	SetOrigin(port->portx, port->porty);
	clipRect.top    = netscapeWindow->clipRect.top    + port->porty;
	clipRect.left   = netscapeWindow->clipRect.left   + port->portx;
	clipRect.bottom = netscapeWindow->clipRect.bottom + port->porty;
	clipRect.right  = netscapeWindow->clipRect.right  + port->portx;
	if (clipRect.top == 0 && clipRect.left ==0 && clipRect.bottom==0 && clipRect.right==0) {
		// Not sure what to do IE is lying... this gets the full screen, not a table cell GetPortBounds(GetWindowPort(stWindow),&clipRect);
	}
	ClipRect(&clipRect);
	BackColor(whiteColor);  /* needed to avoid funny colors */
}

/*** Image File Reading ***/

void ReadSqueakImage(void) {
	sqImageFile f;
	char msg[500];
    int swapBytes;
    int dataSize;
    int headerStart;
    int headerSize;
    int heapSize;
    
	plugInInit(squeakPluginImageName);
	InitFilePaths();

	/* read the image file and allocate memory for Squeak heap */
	f = sqImageFileOpen(imageName, "rb");
	if (f == NULL) {
		strcpy(msg, "Could not open Squeak image file \"");
		strcat(msg, imageName);
		strcat(msg, "\"");
		plugInNotifyUser(msg);
		return;
	}
	
	//Cheat and peek ahead to get the image size so we can calculate the memory required 
	
	swapBytes = checkImageVersionFromstartingAt(f, 0);
	headerStart = (sqImageFilePosition(f)) - 4;
	headerSize = getLongFromFileswap(f, swapBytes);
	dataSize = getLongFromFileswap(f, swapBytes);
	
	//Close then reopen to reset file position
	
	sqImageFileClose(f);  
	f = sqImageFileOpen(imageName, "rb");

	squeakHeapMBytes = parseMemorySize(dataSize, rememberMemoryString);
	if (squeakHeapMBytes == 0) 
	    squeakHeapMBytes = STARTINGsqueakHeapMBytes;
	    
	readImageFromFileHeapSizeStartingAt(f, squeakHeapMBytes, 0);
	sqImageFileClose(f);
	interruptKeycode = 515;  /* ctrl-C, since Netscape blocks cmd-. */
	fullScreenFlag=false; //Note image can be saved with true

}

/*** URL Requests ***/

int URLRequestCreate(char *url, char *target, int semaIndex) {
  /* Start a URL request and return its index. Return -1 if there were
     no idle request handles. */

	int handle, notifyData;
	long junk;

	handle = FindIdleURLRequest();
	if (handle < 0) return handle;
	urlRequests[handle].id = nextRequestID++;
	urlRequests[handle].status = STATUS_IN_PROGRESS;
	urlRequests[handle].semaIndex = semaIndex;
	urlRequests[handle].buffer = null;

	/* temporarily return the grafPort to Netscape so it can display feedback: */
	EndDraw();
	notifyData = (urlRequests[handle].id << 8) + handle;
	NPN_GetURLNotify(thisInstance, url, target, (void *) notifyData);

	Delay(120, (unsigned long *) &junk);  /* workaround for a bug in Mac Netscape 4.7--
						  back-to-back requests to a server sometimes fail
						  when the server was heavily loaded Question is this value too long!*/
	StartDraw();
	return handle;
}

int URLPostCreate(char *url, char *buffer, char * window,int semaIndex) {
  /* Start a URL request and return its index. Return -1 if there were
     no idle request handles. */

	int handle, notifyData;
	long junk;
	NPError error;
	
	handle = FindIdleURLRequest();
	if (handle < 0) return handle;
	urlRequests[handle].id = nextRequestID++;
	urlRequests[handle].status = STATUS_IN_PROGRESS;
	urlRequests[handle].semaIndex = semaIndex;
	urlRequests[handle].buffer = buffer;

	/* temporarily return the grafPort to Netscape so it can display feedback: */
	EndDraw();
	notifyData = (urlRequests[handle].id << 8) + handle;
	error = NPN_PostURLNotify(thisInstance, url, window, strlen(buffer)+1, buffer, false, (void *) notifyData);
	if (error != NPERR_NO_ERROR) {
		StartDraw();
		return -1;
	}
	
	Delay(120, (unsigned long *) &junk);  /* workaround for a bug in Mac Netscape 4.7--
						  back-to-back requests to a server sometimes fail
						  when the server was heavily loaded Question is this value too long!*/
	StartDraw();
	if (window[0] == 0x00) {
		//Bug? unsure, but if window is null, then no notification give so trigger semaphore
		URLRequestCompleted(notifyData,null);
	}	
	return handle;
}

void URLRequestDestroy(int requestHandle) {
  /* Clear the url request with the given handle. */

	if ((requestHandle < 0) || (requestHandle >= URL_REQUEST_COUNT)) {
		return;
	}
	urlRequests[requestHandle].id = 0;
	urlRequests[requestHandle].status = STATUS_IDLE;
	urlRequests[requestHandle].semaIndex = 0;
	urlRequests[requestHandle].fileName[0] = 0;
	urlRequests[requestHandle].buffer = null;
}

char * URLRequestFileName(int requestHandle) {
  /* Return the filename associated with the url request with the given
     handle. Return null if the request status is not STATUS_SUCCEEDED. */

	if ((requestHandle < 0) ||
		(requestHandle >= URL_REQUEST_COUNT) ||
		(urlRequests[requestHandle].status != STATUS_SUCCEEDED)) {
			return null;
	}

	return urlRequests[requestHandle].fileName;
}

int URLRequestStatus(int requestHandle) {
  /* Return the status of the url request with the given handle. */

	if ((requestHandle < 0) ||
		(requestHandle >= URL_REQUEST_COUNT) ||
		(urlRequests[requestHandle].status < STATUS_IN_PROGRESS)) {
			return STATUS_BAD_HANDLE;
	}
	return urlRequests[requestHandle].status;
}

int FindIdleURLRequest(void) {
  /* Return the index of an idle request or -1 if there are none. */
	int i;

	for (i = 0; i < URL_REQUEST_COUNT; i++) {
		if (urlRequests[i].status == STATUS_IDLE) {
			return i;
		}
	}
	return -1;
}

void URLRequestCompleted(int notifyData, const char* fileName) {
  /* Record that the given request has completed, caching the result in
     the given file name. */

	int handle = notifyData & 0xFF;

	if ((handle < 0) || (handle >= URL_REQUEST_COUNT)) {
		return;
	}
	if (urlRequests[handle].id == (notifyData >> 8)) {
		if (fileName != null) 
		    strncpy(urlRequests[handle].fileName, fileName, MAX_STRING_LENGTH);
		if (urlRequests[handle].buffer != null) {
			NPN_MemFree(urlRequests[handle].buffer);
			urlRequests[handle].buffer = null;
		}
		urlRequests[handle].status = STATUS_SUCCEEDED;
		signalSemaphoreWithIndex(urlRequests[handle].semaIndex);
	}
}

void URLRequestFailed(int notifyData, int reason) {
  /* Record that the given URL request failed. */

	int handle = notifyData & 0xFF;

	if ((handle < 0) || (handle >= URL_REQUEST_COUNT)) {
		return;
	}
	if (urlRequests[handle].id == (notifyData >> 8)) {
		if (urlRequests[handle].buffer != null) {
			NPN_MemFree(urlRequests[handle].buffer);
			urlRequests[handle].buffer = null;
		}
		/* Note: For local files, we''re informed that there was a network
		   error (but only after NPP_StreamAsFile has reported success).
		   We could allow local files to be read through the URL request
		   mechanism but NOT failing here if the status has already been
		   set to success. But we don''t want to allow the URL mechanism
		   to be used as a loophole to read files outside the sandbox, so
		   we let this fail. */
		if (urlRequests[handle].status != STATUS_SUCCEEDED) {
			urlRequests[handle].status = STATUS_FAILED;
			signalSemaphoreWithIndex(urlRequests[handle].semaIndex);
		}
	}
}

void InitURLRequestTable(void) {
  /* Initialize the table of URL requests. */
	int i;

	for (i = 0; i < URL_REQUEST_COUNT; i++) {
		URLRequestDestroy(i);
	}
	nextRequestID = 1;
}

/*** Squeak I/O Support and Memory Allocation ***/

int ioExit(void) {
  /* Request that we stop running plugin. */

	ioSetFullScreenRestore();
	plugInForceTimeToReturn();
	exitRequested = true;
}

int ioScreenSize(void) {
	int w = 0, h = 0;
	Rect bounds;
	
	if (netscapeWindow != nil) {
		w = netscapeWindow->clipRect.right - netscapeWindow->clipRect.left;
		h = netscapeWindow->clipRect.bottom - netscapeWindow->clipRect.top;
	}
	    
	if (w == 0 && h == 0) { 
	    GetPortBounds(GetWindowPort(stWindow),&bounds);
		w = bounds.right - bounds.left;
		h = bounds.bottom - bounds.top;
	}
	
	return (w << 16) | (h & 0xFFFF);  /* w is high 16 bits; h is low 16 bits */
}

/* Full Screen logic */

Ptr gRestorableStateForScreen = nil;
NP_Port	  gFullScreenNPPort;
NPWindow  *oldNetscapeWindow,gFullScreenNPWindow;
WindowPtr oldStWindow;

int ioSetFullScreen(int fullScreen) {
	short desiredWidth,desiredHeight;
	
    plugInForceTimeToReturn();
	if (fullScreen) {
	    if (fullScreenFlag) return;
		desiredWidth = 0;
		desiredHeight = 0;
		oldNetscapeWindow = netscapeWindow;
		oldStWindow = stWindow;
		BeginFullScreen	(&gRestorableStateForScreen,nil,
								 &desiredWidth,
								 &desiredHeight,
								 &gAFullscreenWindow,
								 nil,
								 fullScreenAllowEvents);
		fullScreenFlag = true;
		stWindow = gAFullscreenWindow;
		gFullScreenNPPort.port = (CGrafPort *) gAFullscreenWindow;
		gFullScreenNPPort.portx = 0;
		gFullScreenNPPort.porty = 0;
		gFullScreenNPWindow.window =  &gFullScreenNPPort;
		gFullScreenNPWindow.x = 0;
		gFullScreenNPWindow.y = 0;
		gFullScreenNPWindow.width = desiredWidth;
		gFullScreenNPWindow.height = desiredHeight;
		gFullScreenNPWindow.clipRect.top = 0;
		gFullScreenNPWindow.clipRect.left = 0;
		gFullScreenNPWindow.clipRect.bottom = desiredHeight;
		gFullScreenNPWindow.clipRect.right = desiredWidth;
    	
    	netscapeWindow = &gFullScreenNPWindow;
    	ignoreFirstEvent = true;
 	} else {
	    if (!fullScreenFlag) return;
		fullScreenFlag = false;
        ioSetFullScreenRestore();
	}

}

void ioSetFullScreenRestore()
{
	if (gRestorableStateForScreen != nil) {
		EndFullScreen(gRestorableStateForScreen,nil);
	    if (gAFullscreenWindow == nil) 
		    return;
	    gRestorableStateForScreen = nil;
	    netscapeWindow = oldNetscapeWindow;
	    stWindow = oldStWindow;
	}
}

void * sqAllocateMemory(int minHeapSize, int desiredHeapSize) {
  /* Allocate the Squeak object heap memory from the system heap. */

#if TARGET_API_MAC_CARBON
	return NewPtr(desiredHeapSize);
#else
	return NewPtrSys(desiredHeapSize);
#endif
}

/*** File and Access Paths ***/

int InitFilePaths(void) {
	short vRefNum;
	char imageInPreferenceFolder[256];
	long dirID;
	OSErr err;
	FSSpec fileSpec;
	
	/* clear all path and file names */
	imageName[0] = shortImageName[0] = documentName[0] = vmPath[0] = 0;

	strcpy(shortImageName, squeakPluginImageName);

	/* get the path to the sytem folder preference area*/
	err = FindFolder(kOnSystemDisk, kPreferencesFolderType, kDontCreateFolder, &vRefNum, &dirID);
	if (err != noErr) {
		strcpy(imageName,"Problems finding System Preference folder");
		return err;
	}
	
	// Look for folder, if not found abort */
	strcpy(imageInPreferenceFolder,":Squeak:Internet:");
	strcat(imageInPreferenceFolder,shortImageName);
	CopyCStringToPascal(imageInPreferenceFolder,(unsigned char *) imageInPreferenceFolder);
	err = FSMakeFSSpec(vRefNum, dirID,(unsigned char *) imageInPreferenceFolder , &fileSpec);
	if (err != noErr) {
		strcpy(imageName,"Problems finding Internet folder in Squeak Preference folder and SqueakPlugin.image");
		return err;
	}	
	/* set the vmPath */
	PathToPreferenceDir(vmPath,VMPATH_SIZE,fileSpec.vRefNum,fileSpec.parID);
	strcpy(imageName, vmPath);
	strcat(imageName, shortImageName);
}

int PathToPreferenceDir(char *pathName, long pathNameMax, long volumeID, long directoryID) {
	/* Fill in the given string with the full path from a root volume to
	   to current preference directory.
	*/

	Str255 thisName;
	CInfoPBRec pb;
	int nextDirRefNum, pathLen;

	/* initialize string copying state */
	pathName[0] = 0;
	pathLen = 0;

	/* get refNum of working directory */
	strcpy((char *) thisName, ":");
	CopyCStringToPascal((const char *)thisName,thisName);
	pb.hFileInfo.ioNamePtr = thisName;
	pb.hFileInfo.ioVRefNum = volumeID;
	pb.hFileInfo.ioFDirIndex = 0;
	pb.hFileInfo.ioDirID = directoryID;
	if (PBGetCatInfoSync(&pb) != noErr) {
		nextDirRefNum = 0;
	}
	nextDirRefNum = pb.hFileInfo.ioDirID;

	while (true) {
		thisName[0] = 0;
		pb.hFileInfo.ioFDirIndex = -1; /* map ioDirID -> name */
		pb.hFileInfo.ioVRefNum = volumeID;
		pb.hFileInfo.ioDirID = nextDirRefNum;
    	if (PBGetCatInfoSync(&pb) != noErr) {
 			break;  /* we''ve reached the root */
		}
    	CopyPascalStringToC((unsigned char *)thisName,(char *) thisName);
		pathLen = PrefixPathWith(pathName, pathLen, pathNameMax,(char *) thisName);
		nextDirRefNum = pb.dirInfo.ioDrParID;
	}
	return pathLen;
}


int IsPrefixedBy(char *s, char *prefix) {
  /* Return true if the given string begins with or equals the given prefix. */
	int i;

	for (i = 0; prefix[i] != 0; i++) {
		if (s[i] != prefix[i]) 
			return false;
	}
	return true;
}

int plugInAllowAccessToFilePath(char *pathString, int pathStringLength) {
  /* Return true if access to the given file is allowed. */
	int i;
	char path[2000];

	/* copy path into C string */
	if (pathStringLength >= 2000) return false;  /* path too long */
	memcpy(path,pathString,pathStringLength+1);
	path[pathStringLength] = '':'';
	path[pathStringLength+1] = 0;

	/* disallow relative path names that might access a parent folder */
	for (i = 0; i < pathStringLength; i++) {
		if ((path[i] == '':'') && (path[i+1] == '':'')) {
			return false;
		}
	}
	/* check for directory, thus we need to check directory otherwise fallback to default directory */
	for (i = 0; i < pathStringLength; i++)
	    if (path[i] == '':'') return IsPrefixedBy(path, vmPath);
	
    return false;  //Sigh default is where browser is not preference folder
}

/*** Optional URL Fetch Primitives ***/

#ifdef ENABLE_URL_FETCH
int primitivePluginBrowserReady(void) {
	/* Args: none.
	   Always return true on Macintosh. */

	interpreterProxy->pop(1);
	interpreterProxy->pushBool(1);
}

int primitivePluginDestroyRequest(void) {
	/* Args: handle.
	   Destroy the given request. */

	int handle;

	handle = interpreterProxy->stackIntegerValue(0);
	if (interpreterProxy->failed()) {
		return null;
	}
	URLRequestDestroy(handle);
	interpreterProxy->pop(1);
}

int primitivePluginRequestFileHandle(void) {
	/* Args: handle.
	   Return a file handle for the completed request. Fail if
	   the request handle is not valid or hasn''t successfully completed. */

	int handle, fileObj;
	char *fileName;
	SQFile *filePtr;

	handle = interpreterProxy->stackIntegerValue(0);
	if (interpreterProxy->failed()) {
		return null;
	}

	fileName = URLRequestFileName(handle);
	if (fileName == null) {
		interpreterProxy->success(false);
		return null;
	}

	fileObj = interpreterProxy->instantiateClassindexableSize(
		interpreterProxy->classByteArray(), sizeof(SQFile));
	filePtr = (SQFile *) (fileObj + 4);

	/* Note: OpenFileReadOnly() allows any file on the disk to be read via a file URL.
	   However, we are using it for now because we are not sure where the Netscape cache
	   folder will be--it''s folder might even be user-name dependent. sqFileOpen() will
	   only allow opening files within the sandbox, which would be better. Here''s the
	   sandbox-safe alternative:
		  sqFileOpen(filePtr, (int) fileName, strlen(fileName), false);
	*/
	OpenFileReadOnly(filePtr, fileName);

	if (interpreterProxy->failed()) {
		return null;
	}
	interpreterProxy->pop(2);
	interpreterProxy->push(fileObj);
}

int primitivePluginRequestState(void) {
	/* Args: handle.
	   Return true if the request succeeded, false if it failed, and nil if
	   it is still in progress. Fail if the request handle is not valid. */

	int handle;
	int status;
	int resultObj;

	handle = interpreterProxy->stackIntegerValue(0);
	if (interpreterProxy->failed()) {
		return null;
	}

	status = URLRequestStatus(handle);
	if (status == STATUS_BAD_HANDLE) {
		interpreterProxy->success(false);
		return null;
	}

	/* default return object: (nil means "in progress") */
	resultObj = interpreterProxy->nilObject();

	if (status == STATUS_FAILED) {
		resultObj = interpreterProxy->falseObject();
	}
	if (status == STATUS_SUCCEEDED) {
		resultObj = interpreterProxy->trueObject();
	}

	interpreterProxy->pop(2);
	interpreterProxy->push(resultObj);
}

int primitivePluginRequestURL(void) {
	/* Args: url, target, semaphoreIndex.
	   Start a URL request to fetch the given URL to the given target.
	   (See the Netscape Plugin programmer''s manual for possible targets.)
	   Return a handle that can be used to identify this request. Fail if
	   there are already too many outstanding requests. */

	char *urlPtr;
	char *targetPtr;
	int semaIndex;
	int urlObj, urlSize;
	int targetObj, targetSize;
	char url[MAX_STRING_LENGTH + 1];
	char target[MAX_STRING_LENGTH + 1];
	int i;
	int handle;

	semaIndex = interpreterProxy->stackIntegerValue(0);
	targetObj = interpreterProxy->stackObjectValue(1);
	urlObj = interpreterProxy->stackObjectValue(2);
	interpreterProxy->success(interpreterProxy->isBytes(targetObj));
	interpreterProxy->success(interpreterProxy->isBytes(urlObj));
	if (interpreterProxy->failed()) {
		return null;
	}
	urlSize = interpreterProxy->stSizeOf(urlObj);
	urlPtr = interpreterProxy->firstIndexableField(urlObj);
	targetSize = interpreterProxy->stSizeOf(targetObj);
	targetPtr = interpreterProxy->firstIndexableField(targetObj);

	/* copy url into a C string */
	if (urlSize > MAX_STRING_LENGTH) urlSize = MAX_STRING_LENGTH;
	for (i = 0; i < urlSize; i++) {
		url[i] = urlPtr[i];
	}
	url[urlSize] = 0;

	interpreterProxy->success(AbortIfFileURL(url));
	if (interpreterProxy->failed()) {
		return null;
	}
	
	/* copy target into a C string */
	if (targetSize > MAX_STRING_LENGTH) targetSize = MAX_STRING_LENGTH;
	for (i = 0; i < targetSize; i++) {
		target[i] = targetPtr[i];
	}
	target[targetSize] = 0;

	handle = URLRequestCreate(url, target, semaIndex);
	interpreterProxy->success(handle >= 0);

	if (interpreterProxy->failed()) {
		return null;
	}
	interpreterProxy->pop(4);
	interpreterProxy->pushInteger(handle);
}

int primitivePluginPostURL(void) {
	/* Args: url, target, semaphoreIndex.
	   Start a URL request to post the given URL to the given target.
	   (See the Netscape Plugin programmer''s manual for possible targets.)
	   Return a handle that can be used to identify this request. Fail if
	   there are already too many outstanding requests. */

	char *urlPtr;
	char *targetPtr;
	char *bufferPtr,*buffer;
	int semaIndex;
	int urlObj, urlSize;
	int targetObj, targetSize;
	int bufferObj, bufferSize;
	char url[MAX_STRING_LENGTH + 1];
	char target[MAX_STRING_LENGTH + 1];
	int i;
	int handle;

	semaIndex = interpreterProxy->stackIntegerValue(0);
	bufferObj = interpreterProxy->stackObjectValue(1);
	targetObj = interpreterProxy->stackObjectValue(2);
	urlObj = interpreterProxy->stackObjectValue(3);
	
	interpreterProxy->success(interpreterProxy->isBytes(targetObj));
	interpreterProxy->success(interpreterProxy->isBytes(urlObj));
	interpreterProxy->success(interpreterProxy->isBytes(bufferObj));
	if (interpreterProxy->failed()) {
		return null;
	}
	urlSize = interpreterProxy->stSizeOf(urlObj);
	urlPtr = interpreterProxy->firstIndexableField(urlObj);
	targetSize = interpreterProxy->stSizeOf(targetObj);
	targetPtr = interpreterProxy->firstIndexableField(targetObj);
	bufferSize = interpreterProxy->stSizeOf(bufferObj);
	bufferPtr = interpreterProxy->firstIndexableField(bufferObj);

	/* copy url into a C string */
	if (urlSize > MAX_STRING_LENGTH) urlSize = MAX_STRING_LENGTH;
	for (i = 0; i < urlSize; i++) {
		url[i] = urlPtr[i];
	}
	url[urlSize] = 0;

	interpreterProxy->success(AbortIfFileURL(url));
	if (interpreterProxy->failed()) {
		return null;
	}
	
	/* copy target into a C string */
	if (targetSize > MAX_STRING_LENGTH) targetSize = MAX_STRING_LENGTH;
	for (i = 0; i < targetSize; i++) {
		target[i] = targetPtr[i];
	}
	target[targetSize] = 0;

	/* copy over the post buffer which might be large*/
	
	buffer = (char *) NPN_MemAlloc(bufferSize+1);
	for (i = 0; i < bufferSize; i++) {
		buffer[i] = bufferPtr[i];
	}
	buffer[bufferSize] = 0;

	handle = URLPostCreate(url, buffer,target,semaIndex) ;
	interpreterProxy->success(handle >= 0);

	if (interpreterProxy->failed()) {
		return null;
	}
	interpreterProxy->pop(5);
	interpreterProxy->pushInteger(handle);
}

int primitivePluginRequestURLStream(void) {
	/* Args: url, semaphoreIndex.
	   Start a URL request to fetch the given URL. Return a handle that
	   can be used to identify this request. Fail if there are already
	   too many outstanding requests. */

	int urlObj, urlSize, semaIndex;
	char *urlPtr;
	char url[MAX_STRING_LENGTH + 1];
	int handle, i;

	semaIndex = interpreterProxy->stackIntegerValue(0);
	urlObj = interpreterProxy->stackObjectValue(1);
	interpreterProxy->success(interpreterProxy->isBytes(urlObj));
	if (interpreterProxy->failed()) {
		return null;
	}
	urlSize = interpreterProxy->stSizeOf(urlObj);
	urlPtr = interpreterProxy->firstIndexableField(urlObj);

	/* copy url into a C string */
	if (urlSize > MAX_STRING_LENGTH) urlSize = MAX_STRING_LENGTH;
	for (i = 0; i < urlSize; i++) {
		url[i] = urlPtr[i];
	}
	url[urlSize] = 0;

	interpreterProxy->success(AbortIfFileURL(url));
	if (interpreterProxy->failed()) {
		return null;
	}

	handle = URLRequestCreate(url, null, semaIndex);
	interpreterProxy->success(handle >= 0);

	if (interpreterProxy->failed()) {
		return null;
	}
	interpreterProxy->pop(3);
	interpreterProxy->pushInteger(handle);
}


void OpenFileReadOnly(SQFile *f, char *fileName) {
	/* Opens the given file for reading using the supplied sqFile
	   structure. This is a simplified version of sqFileOpen() that
	   avoids the "sandbox" access check, since the browser''s
	   cache folder is outside the Squeak sandbox. That is why
	   we only allow reading of this file. Sets the primitive
	   failure flag if not successful. */

	f->file = fopen(fileName, "rb");
	f->writable = false;

	if (f->file == NULL) {
		f->sessionID = 0;
		f->fileSize = 0;
		interpreterProxy->success(false);
		return;
	} else {
		f->sessionID = thisSession;
		/* compute and cache file size */
		fseek(f->file, 0, SEEK_END);
		f->fileSize = ftell(f->file);
		fseek(f->file, 0, SEEK_SET);
	}
	f->lastOp = 0;
}

#endif

/*** Other ***/

int CaseInsensitiveMatch(char *s1, char *s2) {
  /* Return true if the two strings are the same, not considering case. */
	int len, i, c1, c2;

	len = strlen(s1);
	if (strlen(s2) != len) return false;
	for (i = 0; i < len; i++) {
		c1 = s1[i];
		c2 = s2[i];
		if ((c1 >= ''a'') && (c1 <= ''z'')) {
			c1 = c1 - (''a'' - ''A'');
		}
		if ((c2 >= ''a'') && (c2 <= ''z'')) {
			c2 = c2 - (''a'' - ''A'');
		}
		if (c1 != c2) return false;
	}
	return true;
}

void ExitCleanup(void) {
  /* Clean up and stop running plugin. */

	if (thisInstance == nil) return;
	thisInstance = nil;
	plugInShutdown();
	ioSetFullScreenRestore();
	NPP_Initialize();  /* reset local variables */
}

int StringToInteger(char *s) {
  /* Answer the integer resulting from converting the given
     string, assumed to be decimal integer. */
	int sign, n, i, ch;

	sign = 1;
	n = 0;
	i = 0;
	while ((ch = s[i++]) != 0) {
		if ((ch == ''-'') && (i == 1)) {
			sign = -1;
		} else {
			if ((ch >= ''0'') && (ch <= ''9'')) {
				n = (10 * n) + (ch - ''0'');
			} else {
				return sign * n;
			}
		}
	}
	return sign * n;
}

/*** Interpreter Hooks ***/

void plugInForceTimeToReturn(void) {
  /* Ensure that the next call to pluginTimeToReturn() will return true. */
	interpStartTime = TickCount() - 10000;
}

int plugInNotifyUser(char *msg) {
  /* Notify the user that there was a problem starting Squeak. */

	CopyCStringToPascal(msg,notificationMsg); /* copy message, since notification is asynchronous */

	notifyRec.qType = nmType;
	notifyRec.nmMark = false;			/* no mark in applications menu */
	notifyRec.nmIcon = nil;				/* no menu bar icon */
	notifyRec.nmSound = (Handle) -1;	/* -1 means system beep */
	notifyRec.nmStr = notificationMsg;
	notifyRec.nmResp = (NMUPP) -1;		/* -1 means remove notification when user confirms */

	/* add to notification queue */
	NMInstall(&notifyRec);
}

void plugInSetStartTime(void) {
  /* Set that time at which interpret() was started. */
	interpStartTime = TickCount();
}

int plugInTimeToReturn(void) {
  /* Return true if it is time to return from interpret(). */
    EventRecord evt;
    int delta = TickCount() - interpStartTime;

    if ((delta < 0) || (delta >= 20)) {
        /* let Netscape have control every so often whether or
           not there are pending events */
        return true;
    }
    if ((delta & 0x3) == 0x3) {
        /* check every 4 ticks; if pending events, return to the browser */
        if (OSEventAvail(everyEvent, &evt)) return true;
    }
    return false;
}

int parseMemorySize(int baseSize, char *src)
{
	char buf[50], *tmp;
	int imageSize = 0, requestedSize;

	while(*src) {
		switch(*src) {
			case '' '': /* white spaces; ignore */
			case ''"'':
				src++; break;
			case ''*'': /* multiple of image size */
				tmp = buf; src++;
				while(*src && isdigit(*src)) *(tmp++) = *(src++); /* integer part */
				if(*src == ''.'') { /* fraction part */
					*(tmp++) = *(src++);
					while(*src && isdigit(*src)) *(tmp++) = *(src++);
				}
				*(tmp++) = 0;
				imageSize += (int) (baseSize * atof(buf));
				break;
			case ''+'': /* additional space in bytes */
				tmp = buf; src++;
				while(*src && isdigit(*src)) *(tmp++) = *(src++);
				*(tmp++) = 0;
				if (imageSize == 0) 
					imageSize = baseSize;
				requestedSize = atoi(buf);
				imageSize += (requestedSize <= 1000) ? requestedSize*1024*1024 : requestedSize;
				break;
			default: /* absolute size */
				tmp = buf;
				*(tmp++) = *(src++);
				while(*src && isdigit(*src)) *(tmp++) = *(src++);
				*(tmp++) = 0;
				requestedSize = atoi(buf);
				imageSize = (requestedSize <= 1000) ? requestedSize*1024*1024 : requestedSize;
		}
	}
	return imageSize;
}

int AbortIfFileURL(char *url)
{   char lookFor[6];
	int i=0,placement=0;
	
	lookFor[5] = 0x00;
	while (true) {
		if (*url == 0x00) break;
		if (*url == '' '') {
			url++;
		} else {
		  lookFor[placement++] = *url++;
		  if (placement == 5) break;
		}
	}
	return !CaseInsensitiveMatch(lookFor,"file:");
}'