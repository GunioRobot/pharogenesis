macNetworkFile

	^ '#include <MacHeaders.h>
#include <Events.h>
#include <Devices.h>
#include <Processes.h>
#include <Traps.h>

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>
#include "MacTCP.h"
#include "AddressXLation.h"

#include "sq.h"

/*** Socket TYpe Constants ***/
#define TCPSocketType 0
#define UDPSocketType 1

/*** Resolver Status Constants ***/
#define RESOLVER_UNINITIALIZED	0
#define RESOLVER_SUCCESS		1
#define RESOLVER_BUSY			2
#define RESOLVER_ERROR			3

/* Resolver State */
typedef struct {
	int				semaIndex;
	int				status;
	int				error;
	int				localAddress;
	int				remoteAddress;
	struct hostInfo	hostInfo;
} ResolverStatusRec, *ResolverStatusPtr;

/*** TCP Socket Status Constants ***/
#define Unconnected				0
#define WaitingForConnection	1
#define Connected				2
#define OtherEndClosed			3
#define ThisEndClosed			4

/*** TCP Socket State ***/
#define SendBufferSize	(8 * 1024)
#define RecvBufferSize	(8 * 1024)
typedef struct {
	TCPiopb		tcpPB;				/* TCP parameter block for open/send (must be first) */
	TCPiopb		closePB;			/* TCP parameter block for close */
	StreamPtr	tcpStream;			/* TCP stream */
	void *		next;				/* next socket in a linked list of sockets */
	int			semaIndex;
	int			connectStatus;
	int			dataAvailable;		/* suggests that data may be available */
	int			sendInProgress;
	int			lastError;
//xxx	char		sendBuf[SendBufferSize];
	char		rcvBuf[1];			/* must be last; length set when allocated */
} TCPSockRec, *TCPSockPtr;

typedef struct {
	TCPiopb		tcpPB;
	TCPSockPtr	mySocket;
	struct wdsEntry wds[2];
	char		data[SendBufferSize];
} TCPSendBuf, *TCPSendBufPtr;

#define SendBufCount 8
TCPSendBuf sendBufPool[SendBufCount];
int nextSendBuf = 0;

/*** UDP Socket Status Constants ***/
#define UnknowRemoteAddrAndPort	0
#define Ready					1

/*** UDP Socket State ***/
typedef struct {
	void *		next;				/* next socket in a linked list of sockets */
	int			remoteAddress;
	int			remotePort;
	int			semaIndex;
	int			connectStatus;
	int			dataAvailable;		/* suggests that data may be available */
	int			sendInProgress;
	int			lastError;
	char		sendBuf[SendBufferSize];
	char		rcvBuf[1];			/* must be last; length set when allocated */
} UDPSockRec, *UDPSockPtr;

/*** Variables ***/

short				macTCPRefNum = 0;
int					mtuSize = 1024;
TCPSockPtr 			openTCPSockets = nil;
UDPSockPtr			openUDPSockets = nil;
ResolverStatusRec 	resolver = {0, 0, 0, 0, 0, 0, 0};

UniversalProcPtr	myExitHandlerProc = nil;
UniversalProcPtr	oldExitHandlerProc = nil;
ResultUPP			resolverDoneProc = nil;
TCPIOCompletionUPP	tcpCloseDoneProc = nil;
TCPIOCompletionUPP	tcpConnectDoneProc = nil;
TCPNotifyUPP		tcpNotifyProc = nil;
TCPIOCompletionUPP	tcpSendDoneProc = nil;
UDPNotifyUPP		udpNotifyProc = nil;
UDPIOCompletionUPP	udpSendDoneProc = nil;

int					thisNetSession = 0;

/*** Private TCP Socket Functions ***/
void *		TCPSockCreate(void);
void		TCPSockDestroy(TCPSockPtr s);
void		TCPSockRemoveFromOpenList(TCPSockPtr s);

int			TCPSockLocalAddress(TCPSockPtr s);
int			TCPSockLocalPort(TCPSockPtr s);
int			TCPSockRemoteAddress(TCPSockPtr s);
int			TCPSockRemotePort(TCPSockPtr s);

void		TCPSockConnectTo(TCPSockPtr s, int addr, int port);
void		TCPSockListenOn(TCPSockPtr s, int port);
void		TCPSockAbortConnection(TCPSockPtr s);
void		TCPSockCloseConnection(TCPSockPtr s);

int			TCPSockDataAvailable(TCPSockPtr s);
int			TCPSockRecvData(TCPSockPtr s, char *buf, int bufSize);
int			TCPSockSendData(TCPSockPtr s, char *buf, int bufSize);

/*** Private UDP Socket Functions ***/
void *		UDPSockCreate(void);
void		UDPSockDestroy(UDPSockPtr s);
void		UDPSockRemoveFromOpenList(UDPSockPtr s);

int			UDPSockLocalAddress(UDPSockPtr s);
int			UDPSockLocalPort(UDPSockPtr s);
int			UDPSockRemoteAddress(UDPSockPtr s);
int			UDPSockRemotePort(UDPSockPtr s);

void		UDPSockConnectTo(UDPSockPtr s, int addr, int port);
void		UDPSockListenOn(UDPSockPtr s, int port);

int			UDPSockRecvData(UDPSockPtr s, char *buf, int bufSize);
int			UDPSockSendData(UDPSockPtr s, char *buf, int bufSize);

/*** Other Private Functions ***/
void		DestroyAllOpenSockets(void);
void		InitTCPCmd(int cmd, StreamPtr tcpStream, TCPiopb *paramBlkPtr);
void		InstallExitHandler(void);
void		MyExitHandler(void);
int			PortNumberValid(int port);
pascal void	ResolverCompletionRoutine(struct hostInfo *hostInfoPtr, char *userDataPtr);
int			ResolverInitialize(int resolverSemaIndex);
void		ResolverTerminate(void);
int			SocketValid(SocketPtr s);
void		TCPCloseCompletionRoutine(struct TCPiopb *s);
void		TCPConnectCompletionRoutine(struct TCPiopb *s);
pascal void	TCPNotificationRoutine(
	StreamPtr s, unsigned short eventCode, Ptr userDataPtr,
	unsigned short terminReason, struct ICMPReport *icmpMsg);
void		TCPSendCompletionRoutine(struct TCPiopb *s);


/*** Network Functions ***/

int sqNetworkInit(int resolverSemaIndex) {
	/* initialize the network and return 0 if successful */
	int localAddr;
	UDPiopb paramBlock;
	OSErr err = noErr;

	if (thisNetSession != 0) return 0;  /* noop if network is already initialized */

	/* open network driver */
	macTCPRefNum = 0;
	err = OpenDriver("\p.IPP", &macTCPRefNum);
	if (err != noErr) {
		return -1;
	}

	/* open resolver */
	err = ResolverInitialize(resolverSemaIndex);
	if (err != noErr) {
		ResolverTerminate();
		return -1;
	}

	/* get local address */
	localAddr = sqResolverLocalAddress();
	if (sqResolverError() != noErr) {
		ResolverTerminate();
		return -1;
	}

	/* compute MTU (maximum transfer unit) size */
	memset(&paramBlock, 0, sizeof(paramBlock));
	paramBlock.csCode = UDPMaxMTUSize;
	paramBlock.csParam.mtu.remoteHost = localAddr;
	paramBlock.ioCRefNum = macTCPRefNum;
	err = PBControlSync((ParmBlkPtr) &paramBlock);
	if (err == noErr) {
		mtuSize = paramBlock.csParam.mtu.mtuSize;	
	} else {
		mtuSize = 1024;  /* guess */
		ResolverTerminate();
		return -1;
	}

	resolverDoneProc	= NewResultProc(ResolverCompletionRoutine);
	tcpCloseDoneProc 	= NewTCPIOCompletionProc(TCPCloseCompletionRoutine);
	tcpConnectDoneProc	= NewTCPIOCompletionProc(TCPConnectCompletionRoutine);
	tcpNotifyProc		= NewTCPNotifyProc(TCPNotificationRoutine);
	tcpSendDoneProc		= NewTCPIOCompletionProc(TCPSendCompletionRoutine);

	InstallExitHandler();

	/* Success! Create a session ID that is unlikely to be
	   repeated. Zero is never used for a valid session number.
	*/
	thisNetSession = clock() + time(NULL);
	if (thisNetSession == 0) thisNetSession = 1;  /* don''t use 0 */
	return 0;
}

void sqNetworkShutdown(void) {
	/* shut down the network */

	if (thisNetSession == 0) return;  /* noop if network is already shut down */
	ResolverTerminate();
	DestroyAllOpenSockets();
	thisNetSession = 0;
}

/*** Squeak Generic Socket Functions ***/

void sqSocketAbortConnection(SocketPtr s) {
	if (!SocketValid(s)) return;
	if (s->socketType == TCPSocketType) {
		TCPSockAbortConnection((TCPSockPtr) s->privateSocketPtr);
	} else {
		success(false);
	}
}

void sqSocketCloseConnection(SocketPtr s) {
	if (!SocketValid(s)) return;
	if (s->socketType == TCPSocketType) {
		TCPSockCloseConnection((TCPSockPtr) s->privateSocketPtr);
	} else {
		success(false);
	}
}

int sqSocketConnectionStatus(SocketPtr s) {
	if (!SocketValid(s)) return -1;
	if (s->socketType == TCPSocketType) {
		return ((TCPSockPtr) s->privateSocketPtr)->connectStatus;
	} else {
		return ((UDPSockPtr) s->privateSocketPtr)->connectStatus;
	}
}

void sqSocketConnectToPort(SocketPtr s, int addr, int port) {
	if (!SocketValid(s)) return;
	if (!PortNumberValid(port)) return;
	if (s->socketType == TCPSocketType) {
		TCPSockConnectTo((TCPSockPtr) s->privateSocketPtr, addr, port);
	} else {
		UDPSockConnectTo((UDPSockPtr) s->privateSocketPtr, addr, port);
	}
}

void sqSocketCreateNetTypeSocketTypeRecvBytesSendBytesSemaID(
			SocketPtr s, int netType, int socketType,
			int recvBufSize, int sendBufSize, int semaIndex) {
	TCPSockPtr tcpSock = nil;
	UDPSockPtr udpSock = nil;

	/* reference args to suppress compiler warnings about unused variables */
	s; netType; recvBufSize; sendBufSize;

	s->sessionID = 0;
	if (socketType == TCPSocketType) {
		tcpSock = TCPSockCreate();
		if (tcpSock == nil) {
			success(false);
		} else {
			tcpSock->semaIndex = semaIndex;
			tcpSock->next = openTCPSockets;
			openTCPSockets = tcpSock;
			s->sessionID = thisNetSession;
			s->socketType = TCPSocketType;
			s->privateSocketPtr = tcpSock;
		}
	} else {
		udpSock = UDPSockCreate();
		if (udpSock == nil) {
			success(false);
		} else {
			udpSock->semaIndex = semaIndex;
			udpSock->next = openUDPSockets;
			openUDPSockets = udpSock;
			s->sessionID = thisNetSession;
			s->socketType = UDPSocketType;
			s->privateSocketPtr = udpSock;
		}
	}
}

void sqSocketDestroy(SocketPtr s) {
	if (!SocketValid(s)) return;
	if (s->socketType == TCPSocketType) {
		TCPSockDestroy((TCPSockPtr) s->privateSocketPtr);
	} else {
		UDPSockDestroy((UDPSockPtr) s->privateSocketPtr);
	}
	s->sessionID = 0;
	s->socketType = -1;
	s->privateSocketPtr = nil;
}

int sqSocketError(SocketPtr s) {
	if (!SocketValid(s)) return -1;
	if (s->socketType == TCPSocketType) {
		return ((TCPSockPtr) s->privateSocketPtr)->lastError;
	} else {
		return ((UDPSockPtr) s->privateSocketPtr)->lastError;
	}
}

void sqSocketListenOnPort(SocketPtr s, int port) {
	if (!SocketValid(s)) return;
	if (!PortNumberValid(port)) return;
	if (s->socketType == TCPSocketType) {
		TCPSockListenOn((TCPSockPtr) s->privateSocketPtr, port);
	} else {
		UDPSockListenOn((UDPSockPtr) s->privateSocketPtr, port);
	}
}

int sqSocketLocalAddress(SocketPtr s) {
	if (!SocketValid(s)) return -1;
	if (s->socketType == TCPSocketType) {
		return TCPSockLocalAddress((TCPSockPtr) s->privateSocketPtr);
	} else {
		return UDPSockLocalAddress((UDPSockPtr) s->privateSocketPtr);
	}
}

int sqSocketLocalPort(SocketPtr s) {
	if (!SocketValid(s)) return -1;
	if (s->socketType == TCPSocketType) {
		return TCPSockLocalPort((TCPSockPtr) s->privateSocketPtr);
	} else {
		return UDPSockLocalPort((UDPSockPtr) s->privateSocketPtr);
	}
}

int sqSocketReceiveDataAvailable(SocketPtr s) {
	if (!SocketValid(s)) return 0;
	if (s->socketType == TCPSocketType) {
		return TCPSockDataAvailable((TCPSockPtr) s->privateSocketPtr);
	} else {
		return ((UDPSockPtr) s->privateSocketPtr)->dataAvailable;
	}
}

int sqSocketReceiveDataBufCount(SocketPtr s, int buf, int bufSize) {
	int adjustedBufSize = bufSize > 0xFFFF ? 0xFFFF : bufSize;

	if (!SocketValid(s)) return -1;
	if (s->socketType == TCPSocketType) {
		return TCPSockRecvData((TCPSockPtr) s->privateSocketPtr, (char *) buf, adjustedBufSize);
	} else {
		return UDPSockRecvData((UDPSockPtr) s->privateSocketPtr, (char *) buf, adjustedBufSize);
	}
}

int sqSocketRemoteAddress(SocketPtr s) {
	if (!SocketValid(s)) return -1;
	if (s->socketType == TCPSocketType) {
		return TCPSockRemoteAddress((TCPSockPtr) s->privateSocketPtr);
	} else {
		return UDPSockRemoteAddress((UDPSockPtr) s->privateSocketPtr);
	}
}

int sqSocketRemotePort(SocketPtr s) {
	if (!SocketValid(s)) return -1;
	if (s->socketType == TCPSocketType) {
		return TCPSockRemotePort((TCPSockPtr) s->privateSocketPtr);
	} else {
		return UDPSockRemotePort((UDPSockPtr) s->privateSocketPtr);
	}
}

int sqSocketSendDataBufCount(SocketPtr s, int buf, int bufSize) {
	int adjustedBufSize = bufSize > 0xFFFF ? 0xFFFF : bufSize;

	if (!SocketValid(s)) return -1;
	if (s->socketType == TCPSocketType) {
		return TCPSockSendData((TCPSockPtr) s->privateSocketPtr, (char *) buf, adjustedBufSize);
	} else {
		return UDPSockSendData((UDPSockPtr) s->privateSocketPtr, (char *) buf, adjustedBufSize);
	}
}

int sqSocketSendDone(SocketPtr s) {
	if (!SocketValid(s)) return 1;
	if (s->socketType == TCPSocketType) {
		return !((TCPSockPtr) s->privateSocketPtr)->sendInProgress;
	} else {
		return !((UDPSockPtr) s->privateSocketPtr)->sendInProgress;
	}
}

/*** Resolver Functions ***/

void sqResolverAbort(void) {
	int semaIndex;

	/* abort the current request */
	if (resolver.status == RESOLVER_BUSY) {
		semaIndex = resolver.semaIndex;
		ResolverTerminate();
		ResolverInitialize(semaIndex);
	}
}

void sqResolverAddrLookupResult(char *nameForAddress, int nameSize) {
	/* copy the name found by the last address lookup into the given string */
	memcpy(nameForAddress, resolver.hostInfo.cname, nameSize);
}

int sqResolverAddrLookupResultSize(void) {
	return strlen(resolver.hostInfo.cname);
}

int sqResolverError(void) {
	return resolver.error;
}

int sqResolverLocalAddress(void) {
	struct GetAddrParamBlock paramBlock;

	if (resolver.localAddress == 0) {
		resolver.remoteAddress = 0;
		memset(&paramBlock, 0, sizeof(struct GetAddrParamBlock));
		paramBlock.ioResult = 1;
		paramBlock.csCode = ipctlGetAddr;
		paramBlock.ioCRefNum = macTCPRefNum;
		PBControlSync((ParmBlkPtr) &paramBlock);
		if (paramBlock.ioResult == noErr) {
			resolver.status = RESOLVER_SUCCESS;
			resolver.localAddress = paramBlock.ourAddress;
			resolver.error = noErr;
		} else {
			resolver.status = RESOLVER_ERROR;
			resolver.error = paramBlock.ioResult;
		}
	} else {
		resolver.status = RESOLVER_SUCCESS;
		resolver.error = noErr;
	}
	return resolver.localAddress;
}

int sqResolverNameLookupResult(void) {
	/* return the result of the last successful lookup */
	return resolver.remoteAddress;
}

void sqResolverStartAddrLookup(int address) {
	OSErr err;

	if (resolver.status == RESOLVER_BUSY) return;

	resolver.status = RESOLVER_BUSY;
	resolver.error = noErr;
	memset(&resolver.hostInfo, 0, sizeof(hostInfo));
	err = AddrToName(address, &resolver.hostInfo, resolverDoneProc, (char *) &resolver);
	if (err == noErr) {
		/* address was in cache; lookup is already done */
		resolver.status = RESOLVER_SUCCESS;
	} else {
		if (err != cacheFault) {
			/* real error */
			resolver.status = RESOLVER_ERROR;
			resolver.error = err;
		}
	}
}

void sqResolverStartNameLookup(char *hostName, int nameSize) {
	char name[501];
	int len; 
	OSErr err;

	if (resolver.status == RESOLVER_BUSY) return;

	len = ((nameSize <= 500) ? nameSize : 500);
	memcpy(name, hostName, len);
	name[len] = ''\0'';

	resolver.status = RESOLVER_BUSY;
	resolver.error = noErr;
	memset(&resolver.hostInfo, 0, sizeof(hostInfo));
	err = StrToAddr(name, &resolver.hostInfo, resolverDoneProc, (char *) &resolver);
	if (err == noErr) {
		/* address was in cache; lookup is already done */
		resolver.status = RESOLVER_SUCCESS;
		resolver.remoteAddress = resolver.hostInfo.addr[0];
	} else {
		if (err != cacheFault) {
			/* real error */
			resolver.status = RESOLVER_ERROR;
			resolver.error = err;
		}
	}
}

int sqResolverStatus(void) {
	return resolver.status;
}

/*** Private Resolver Functions ***/

int ResolverInitialize(int resolverSemaIndex) {
	if (resolver.status != RESOLVER_UNINITIALIZED) {
		ResolverTerminate();
	}

	memset(&resolver, 0, sizeof(ResolverStatusRec));
	resolver.status = RESOLVER_UNINITIALIZED;

	resolver.error = OpenResolver(nil);
	if (resolver.error != noErr) {
		resolver.status = RESOLVER_ERROR;
		return resolver.error;
	}

	resolver.semaIndex = resolverSemaIndex;
	resolver.status = RESOLVER_SUCCESS;
	return noErr;
}

static pascal void ResolverCompletionRoutine(struct hostInfo *hostInfoPtr, char *userDataPtr) {
	ResolverStatusPtr r = (ResolverStatusPtr) userDataPtr;

	if ((r == null) || (r->status != RESOLVER_BUSY)) return;

	/* completion routine */
	if (r->hostInfo.rtnCode == noErr) {
		r->status = RESOLVER_SUCCESS;
		r->remoteAddress = hostInfoPtr->addr[0];
	} else {
		r->status = RESOLVER_ERROR;
		r->error = hostInfoPtr->rtnCode;
	}
	signalSemaphoreWithIndex(r->semaIndex);
}

void ResolverTerminate(void) {
	CloseResolver();
	memset(&resolver, 0, sizeof(ResolverStatusRec));
	resolver.status = RESOLVER_UNINITIALIZED;
}

/*** Private TCP Socket Functions ***/

void * TCPSockCreate(void) {
	TCPiopb paramBlock;
	TCPSockPtr s = nil;
	int minRcvBufSize, rcvBufSize;
	OSErr err = noErr;

	rcvBufSize = RecvBufferSize;
	minRcvBufSize = (4 * mtuSize) + 1024;
	if (rcvBufSize < minRcvBufSize) rcvBufSize = minRcvBufSize;
	
	s = (TCPSockPtr) malloc(sizeof(TCPSockRec) + rcvBufSize);
	if (s == nil) return nil;  /* allocation failed */
	memset(s, 0, sizeof(TCPSockRec) + rcvBufSize);

	InitTCPCmd(TCPCreate, nil, &paramBlock);
	paramBlock.csParam.create.rcvBuff = s->rcvBuf;
	paramBlock.csParam.create.rcvBuffLen = rcvBufSize;
	paramBlock.csParam.create.notifyProc = tcpNotifyProc;
	paramBlock.csParam.create.userDataPtr = (Ptr) s;
	err = PBControlSync((ParmBlkPtr) &paramBlock);
	if (err != noErr) {
		free(s);
		return nil;
	}
	s->tcpStream = paramBlock.tcpStream;
	return s;
}

int TCPSockDataAvailable(TCPSockPtr s) {
	TCPiopb paramBlock;
	OSErr err = noErr;

	if ((s == nil) || (s->tcpStream == nil)) {
		return false;  /* already destroyed */
	}

	InitTCPCmd(TCPStatus, s->tcpStream, &paramBlock);
	err = PBControlSync((ParmBlkPtr) &paramBlock);
	if (err != noErr) {
		return 0;
	}
	return paramBlock.csParam.status.amtUnreadData > 0;
}

void TCPSockDestroy(TCPSockPtr s) {
	TCPiopb paramBlock;
	OSErr err = noErr;

	if ((s == nil) || (s->tcpStream == nil)) {
		return;  /* already destroyed */
	}

	InitTCPCmd(TCPRelease, s->tcpStream, &paramBlock);
	err = PBControlSync((ParmBlkPtr) &paramBlock);
	TCPSockRemoveFromOpenList(s);
	s->tcpStream = nil;
	free(s);
}

int TCPSockLocalAddress(TCPSockPtr s) {
	TCPiopb paramBlock;

	if ((s == nil) || (s->tcpStream == nil)) {
		return 0;  /* already destroyed */
	}

	InitTCPCmd(TCPStatus, s->tcpStream, &paramBlock);
	s->lastError = PBControlSync((ParmBlkPtr) &paramBlock);
	if (s->lastError != noErr) {
		return 0;
	}
	return paramBlock.csParam.status.localHost;
}

int TCPSockLocalPort(TCPSockPtr s) {
	TCPiopb paramBlock;

	if ((s == nil) || (s->tcpStream == nil)) {
		return 0;  /* already destroyed */
	}

	InitTCPCmd(TCPStatus, s->tcpStream, &paramBlock);
	s->lastError = PBControlSync((ParmBlkPtr) &paramBlock);
	if (s->lastError != noErr) {
		return 0;
	}
	return paramBlock.csParam.status.localPort;
}

int TCPSockRemoteAddress(TCPSockPtr s) {
	TCPiopb paramBlock;

	if ((s == nil) || (s->tcpStream == nil)) {
		return 0;  /* already destroyed */
	}

	InitTCPCmd(TCPStatus, s->tcpStream, &paramBlock);
	s->lastError = PBControlSync((ParmBlkPtr) &paramBlock);
	if (s->lastError != noErr) {
		return 0;
	}
	return paramBlock.csParam.status.remoteHost;
}

int TCPSockRemotePort(TCPSockPtr s) {
	TCPiopb paramBlock;

	if ((s == nil) || (s->tcpStream == nil)) {
		return 0;  /* already destroyed */
	}

	InitTCPCmd(TCPStatus, s->tcpStream, &paramBlock);
	s->lastError = PBControlSync((ParmBlkPtr) &paramBlock);
	if (s->lastError != noErr) {
		return 0;
	}
	return paramBlock.csParam.status.remotePort;
}

void TCPSockRemoveFromOpenList(TCPSockPtr s) {
	TCPSockPtr thisSock, nextSock, previousSock;

	previousSock = nil;
	for (thisSock = openTCPSockets; thisSock != nil; thisSock = nextSock) {
		nextSock = thisSock->next;
		if (thisSock == s) {
			if (previousSock == nil) {
				openTCPSockets = nextSock;
			} else {
				previousSock->next = nextSock;
			}
			break;
		}
		previousSock = thisSock;
	}
}

void TCPSockConnectTo(TCPSockPtr s, int addr, int port) {
	if ((s == nil) || (s->tcpStream == nil)) return;  /* socket destroyed */

	InitTCPCmd(TCPActiveOpen, s->tcpStream, &s->tcpPB);
	s->tcpPB.csParam.open.remoteHost = addr;
	s->tcpPB.csParam.open.remotePort = port;
	s->connectStatus = WaitingForConnection;
	s->tcpPB.ioCompletion = tcpConnectDoneProc;
	s->lastError = PBControlAsync((ParmBlkPtr) &s->tcpPB);
	if (s->lastError != noErr) {
		s->connectStatus = Unconnected;
	}
}

void TCPSockListenOn(TCPSockPtr s, int port) {
	if ((s == nil) || (s->tcpStream == nil)) return;  /* socket destroyed */

	InitTCPCmd(TCPPassiveOpen, s->tcpStream, &s->tcpPB);
	s->tcpPB.csParam.open.localPort = port;
	s->connectStatus = WaitingForConnection;
	s->tcpPB.ioCompletion = tcpConnectDoneProc;
	s->lastError = PBControlAsync((ParmBlkPtr) &s->tcpPB);
	if (s->lastError != noErr) {
		s->connectStatus = Unconnected;
	}
}

void TCPSockCloseConnection(TCPSockPtr s) {
	/* Note: This operation uses a dedicated parameter block so that it
	   can be invoked even in the previous send is not yet complete.
	   It will eventually use a completion routine to delete the
	   socket automatically. For now, this is the client''s responsibility.
	*/
	if ((s == nil) || (s->tcpStream == nil)) return;  /* socket destroyed */

	InitTCPCmd(TCPClose, s->tcpStream, &s->closePB);
//	s->closePB.ioCompletion = tcpCloseDoneProc;
	s->connectStatus = ThisEndClosed; // xxx remove when making this async
	s->lastError = PBControlSync((ParmBlkPtr) &s->closePB);
}

void TCPSockAbortConnection(TCPSockPtr s) {
	TCPiopb paramBlock;

	if ((s == nil) || (s->tcpStream == nil)) return;  /* socket destroyed */

	InitTCPCmd(TCPAbort, s->tcpStream, &paramBlock);
	s->lastError = PBControlSync((ParmBlkPtr) &paramBlock);
	s->connectStatus = Unconnected;
}

int TCPSockRecvData(TCPSockPtr s, char *buf, int bufSize) {
	TCPiopb paramBlock;  /* use local parameter block since send may be using one in socket */
	OSErr err = noErr;
	int bytesRead;

	if (!TCPSockDataAvailable(s)) return 0;  /* no data available */

	InitTCPCmd(TCPRcv, s->tcpStream, &paramBlock);
	paramBlock.csParam.receive.commandTimeoutValue = 1; /* finish in one second, data or not */
	paramBlock.csParam.receive.rcvBuff = buf;
	paramBlock.csParam.receive.rcvBuffLen = bufSize;
	s->lastError = noErr;
	err = PBControlSync((ParmBlkPtr) &paramBlock);  /* synchronous */
	if (err == noErr) {
		bytesRead = paramBlock.csParam.receive.rcvBuffLen;
	} else {
		/* if err == commandTimeout, no data was available */
		bytesRead = 0;
		if (!((err == commandTimeout) || (err == connectionClosing))) {
			s->lastError = err;
		}
	}
	s->dataAvailable = (bytesRead != 0);  /* if we got data, there may be more */
	return bytesRead;
}

int xxxGOODTCPSockSendData(TCPSockPtr s, char *buf, int bufSize);
int xxxGOODTCPSockSendData(TCPSockPtr s, char *buf, int bufSize) {
	int sendCount;
	struct wdsEntry wds[2];

	buf;  /* xxx avoid compiler complaint about unreferenced vars */

	/* copy client data into sendBuf to allow asynchronous send */
	sendCount = (bufSize <= SendBufferSize) ? bufSize : SendBufferSize;
//xxx	memcpy(s->sendBuf, buf, sendCount);

	/* set up WDS entry; zero length marks end of chunk list */
	wds[0].length = sendCount;
//xxx		wds[0].ptr = s->sendBuf;
	wds[1].length = 0;

	InitTCPCmd(TCPSend, s->tcpStream, &s->tcpPB);
	s->tcpPB.csParam.send.wdsPtr = (Ptr) &wds;
	s->tcpPB.csParam.send.pushFlag = true;
	s->sendInProgress = true;
	s->tcpPB.ioCompletion = tcpSendDoneProc;
	s->lastError = PBControlAsync((ParmBlkPtr) &s->tcpPB);
	if (s->lastError != noErr) {
		s->sendInProgress = false;
		return 0;
	}
	return sendCount;
}

int TCPSockSendData(TCPSockPtr s, char *buf, int bufSize) {
	TCPSendBufPtr sendBuf;
	int sendCount;

	sendBuf = &sendBufPool[nextSendBuf++];
	if (nextSendBuf >= SendBufCount) nextSendBuf = 0;
	sendBuf->mySocket = s;
	
	/* copy client data into sendBuf to allow asynchronous send */
	sendCount = (bufSize <= SendBufferSize) ? bufSize : SendBufferSize;
	memcpy(sendBuf->data, buf, sendCount);

	/* set up WDS entry; zero length marks end of chunk list */
	sendBuf->wds[0].length = sendCount;
	sendBuf->wds[0].ptr = sendBuf->data;
	sendBuf->wds[1].length = 0;

	InitTCPCmd(TCPSend, s->tcpStream, &sendBuf->tcpPB);
	sendBuf->tcpPB.csParam.send.wdsPtr = (Ptr) &sendBuf->wds;
	sendBuf->tcpPB.csParam.send.pushFlag = true;
	sendBuf->tcpPB.ioCompletion = tcpSendDoneProc;
	s->sendInProgress = true;
	s->lastError = PBControlAsync((ParmBlkPtr) &sendBuf->tcpPB);
	if (s->lastError != noErr) {
		s->sendInProgress = false;
		return 0;
	}
	return sendCount;
}

/*** Private General Utilities ***/

void DestroyAllOpenSockets(void) {
	while (openTCPSockets != nil) {
		TCPSockDestroy(openTCPSockets);  /* removes socket from the list */
	}
	while (openUDPSockets != nil) {
		UDPSockDestroy(openUDPSockets);  /* removes socket from the list */
	}
}

void InstallExitHandler(void) {
	/* Install a handler to release all open sockets when terminating this
	   application. The handler will be called even if you type ''es'' to
	   MacsBug or use Command-Option-Escape for force the program to exit.
	   The handler is only installed the first time the network is initialized.
	*/

	if (oldExitHandlerProc == nil) {
		oldExitHandlerProc = GetToolTrapAddress(_ExitToShell);
		myExitHandlerProc = 
			NewRoutineDescriptor((ProcPtr) MyExitHandler, kPascalStackBased, GetCurrentISA());
		SetToolTrapAddress(myExitHandlerProc, _ExitToShell);
	}
}

void MyExitHandler(void) {
	SetCurrentA5();
	SetToolTrapAddress(oldExitHandlerProc, _ExitToShell);
	ResolverTerminate();
	DestroyAllOpenSockets();
	ExitToShell();
}

int PortNumberValid(int port) {
	if (port < 0xFFFF) {
		return true;
	}
	success(false);
	return false;
}

int SocketValid(SocketPtr s) {
	if ((s != NULL) &&
		(s->privateSocketPtr != NULL) &&
		(s->sessionID == thisNetSession)) {
			if (s->socketType == TCPSocketType) {
				if (((TCPSockPtr) s->privateSocketPtr)->tcpStream != nil) {
					return true;
				}
			}
	}
	success(false);
	return false;
}

/*** Private TCP Utilities ***/

void InitTCPCmd(int cmd, StreamPtr tcpStream, TCPiopb *paramBlkPtr) {
	memset(paramBlkPtr, 0, sizeof(TCPiopb));
	paramBlkPtr->csCode = cmd;
	paramBlkPtr->tcpStream = tcpStream;
	paramBlkPtr->ioCRefNum = macTCPRefNum;
	paramBlkPtr->ioResult = 1;
}

void TCPCloseCompletionRoutine(struct TCPiopb *pbPtr) {
	TCPSockPtr s = (TCPSockPtr) pbPtr;

	s->lastError = s->tcpPB.ioResult;
	if (s->lastError == noErr) {
		if (s->connectStatus == OtherEndClosed) {
			s->connectStatus = Unconnected;
		} else {
			s->connectStatus = ThisEndClosed;
		}
	}
	signalSemaphoreWithIndex(s->semaIndex);
}

void TCPConnectCompletionRoutine(struct TCPiopb *pbPtr) {
	TCPSockPtr s = (TCPSockPtr) pbPtr;

	s->lastError = s->tcpPB.ioResult;
	if (s->lastError == noErr) {
		s->connectStatus = Connected;
	} else {
		s->connectStatus = Unconnected;
	}
	signalSemaphoreWithIndex(s->semaIndex);
}

pascal void TCPNotificationRoutine(
	StreamPtr s, unsigned short eventCode, Ptr userDataPtr,
	unsigned short terminReason, struct ICMPReport *icmpMsg) {
	/* called when data arrives or stream status changes */

	/* reference args to suppress compiler warnings about unused variables */
	s; terminReason; icmpMsg;
	
	if (eventCode == TCPDataArrival) {
		TCPSockPtr tcpSock = (TCPSockPtr) userDataPtr;
		tcpSock->dataAvailable = true;
		signalSemaphoreWithIndex(tcpSock->semaIndex);
		return;
	}
	if (eventCode == TCPClosing) {
		TCPSockPtr tcpSock = (TCPSockPtr) userDataPtr;
		if (tcpSock->connectStatus == ThisEndClosed) {
			tcpSock->connectStatus = Unconnected;
		} else {
			tcpSock->connectStatus = OtherEndClosed;
		}
		signalSemaphoreWithIndex(tcpSock->semaIndex);
		return;
	}
	if (eventCode == TCPTerminate) {
		TCPSockPtr tcpSock = (TCPSockPtr) userDataPtr;
		tcpSock->connectStatus = Unconnected;
		signalSemaphoreWithIndex(tcpSock->semaIndex);
		return;
	}
}

void TCPSendCompletionRoutine(struct TCPiopb *pbPtr) {
//xxx	TCPSockPtr s = (TCPSockPtr) pbPtr;
TCPSockPtr s = ((TCPSendBufPtr) pbPtr)->mySocket;
	
	s->lastError = s->tcpPB.ioResult;
	s->sendInProgress = false;
	signalSemaphoreWithIndex(s->semaIndex);
}

/*** Private UDP Socket Functions ***/

void *		UDPSockCreate(void) {
	// xxx
	return nil;
}

void		UDPSockDestroy(UDPSockPtr s) {
	// xxx
	s;
}

int			UDPSockLocalAddress(UDPSockPtr s) {
	// xxx
	s;
}

int			UDPSockLocalPort(UDPSockPtr s) {
	// xxx
	s;
}

int			UDPSockRemoteAddress(UDPSockPtr s) {
	// xxx
	s;
}

int			UDPSockRemotePort(UDPSockPtr s) {
	// xxx
	s;
}

void		UDPSockConnectTo(UDPSockPtr s, int addr, int port) {
	// xxx
	s; addr; port;
}

void		UDPSockListenOn(UDPSockPtr s, int port) {
	// xxx
	s; port;
}

int			UDPSockRecvData(UDPSockPtr s, char *buf, int bufSize) {
	// xxx
	s; buf; bufSize;
}

int			UDPSockSendData(UDPSockPtr s, char *buf, int bufSize) {
	// xxx
	s; buf; bufSize;
}
'.
