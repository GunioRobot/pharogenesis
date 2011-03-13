testIPv6
	"NetNameResolver testIPv6"
	| infos size host serverSocket listeningSocket clientSocket |
	World findATranscript: World currentEvent.
	Transcript clear.
	"Transcript show: SmalltalkImage current listLoadedModules; cr."
	self initializeNetwork.
	Transcript show: '---- host name ----'; cr.
	size := NetNameResolver primHostNameSize.
	host := String new: size.
	NetNameResolver primHostNameResult: host.
	Transcript show: host; cr.

	Transcript show: '---- localhost defaults: loopback and wildcard addresses ----'; cr.
	Transcript show: (SocketAddress loopbacks) printString; cr.
	Transcript show: (SocketAddress wildcards) printString; cr.
	Transcript show: (SocketAddress loopback4) printString; cr.
	Transcript show: (SocketAddress wildcard4) printString; cr.
	Transcript show: '---- impossible constraints ----'; cr.
	Transcript show: (SocketAddressInformation
						forHost: 'localhost' service: 'echo' flags: 0
						addressFamily:	0
						socketType:		SocketAddressInformation socketTypeDGram
						protocol:		SocketAddressInformation protocolTCP) printString; cr.
	Transcript show: '---- INET4 client-server ----'; cr.
	Transcript show: (infos := SocketAddressInformation
						forHost: '' service: '4242'
						flags:			SocketAddressInformation passiveFlag
						addressFamily:	SocketAddressInformation addressFamilyINET4
						socketType:		SocketAddressInformation socketTypeStream
						protocol:		SocketAddressInformation protocolTCP) printString; cr.
	listeningSocket := infos first listenWithBacklog: 5.
	Transcript show: (infos := SocketAddressInformation
						forHost: 'localhost' service: '4242'
						flags:			0
						addressFamily:	SocketAddressInformation addressFamilyINET4
						socketType:		SocketAddressInformation socketTypeStream
						protocol:		SocketAddressInformation protocolTCP) printString; cr.
	clientSocket := infos first connect.
	serverSocket := listeningSocket accept.
	serverSocket sendData: 'Hi there!' count: 9.
	Transcript show: clientSocket receiveData; cr.
	Transcript nextPutAll: 'client side local/remote: ';
		print: clientSocket localSocketAddress; space;
		print: clientSocket remoteSocketAddress; cr.
	Transcript nextPutAll: 'server side local/remote: ';
		print: serverSocket localSocketAddress; space;
		print: serverSocket remoteSocketAddress; cr;
		endEntry.
	clientSocket close; destroy.
	serverSocket close; destroy.
	listeningSocket close; destroy.
	Transcript show: '---- INET6 client-server ----'; cr.
	Transcript show: (infos := SocketAddressInformation
						forHost: '' service: '4242'
						flags:			SocketAddressInformation passiveFlag
						addressFamily:	SocketAddressInformation addressFamilyINET6
						socketType:		SocketAddressInformation socketTypeStream
						protocol:		SocketAddressInformation protocolTCP) printString; cr.
	infos isEmpty
		ifTrue: [Transcript show: 'FAIL -- CANNOT CREATE INET6 SERVER'; cr]
		ifFalse:
			[listeningSocket := infos first listenWithBacklog: 5.
			Transcript show: (infos := SocketAddressInformation
								forHost: 'localhost' service: '4242'
								flags:			0
								addressFamily:	SocketAddressInformation addressFamilyINET6
								socketType:		SocketAddressInformation socketTypeStream
								protocol:		SocketAddressInformation protocolTCP) printString; cr.
			clientSocket := infos first connect.
			serverSocket := listeningSocket accept.
			serverSocket sendData: 'Hi there!' count: 9.
			Transcript show: clientSocket receiveData; cr.
			Transcript nextPutAll: 'client side local/remote: ';
				print: clientSocket localSocketAddress; space;
				print: clientSocket remoteSocketAddress; cr.
			Transcript nextPutAll: 'server side local/remote: ';
				print: serverSocket localSocketAddress; space;
				print: serverSocket remoteSocketAddress; cr;
				endEntry.
			clientSocket close; destroy.
			serverSocket close; destroy.
			listeningSocket close; destroy].
	Transcript show: '---- trivial tests done ---'; cr.