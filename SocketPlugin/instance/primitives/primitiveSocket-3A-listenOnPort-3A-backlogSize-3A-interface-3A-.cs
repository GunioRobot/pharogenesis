primitiveSocket: socket listenOnPort: port backlogSize: backlog interface: ifAddr
	"Bind a socket to the given port and interface address with no more than backlog pending connections.  The socket can be UDP, in which case the backlog should be specified as zero."

	| s okToListen addr |
	self var: #s declareC: 'SocketPtr s'.
	self primitive: 'primitiveSocketListenOnPortBacklogInterface' parameters: #(#Oop #SmallInteger #SmallInteger #ByteArray).
	s _ self socketValueOf: socket.
	"If the security plugin can be loaded, use it to check for permission.
	If 
	not, assume it's ok"
	sCCLOPfn ~= 0
		ifTrue: [okToListen _ self cCode: ' ((int (*) (SocketPtr, int)) sCCLOPfn)(s, port)'.
			okToListen
				ifFalse: [^ interpreterProxy primitiveFail]].
	addr _ self netAddressToInt: (self cCoerce: ifAddr to: 'unsigned char *').
	self
		sqSocket: s
		ListenOnPort: port
		BacklogSize: backlog
		Interface: addr