primitiveSocket: socket connectTo: address port: port 
	| addr s okToConnect  |
	self var: #s declareC: 'SocketPtr s'.
	self primitive: 'primitiveSocketConnectToPort' parameters: #(#Oop #ByteArray #SmallInteger ).
	addr _ self
				netAddressToInt: (self cCoerce: address to: 'unsigned char *').
	"If the security plugin can be loaded, use it to check for permission.
	If 
	not, assume it's ok"
	sCCTPfn ~= 0
		ifTrue: [okToConnect _ self cCode: ' ((int (*) (int, int)) sCCTPfn)(addr, port)'.
			okToConnect
				ifFalse: [^ interpreterProxy primitiveFail]].
	s _ self socketValueOf: socket.
	interpreterProxy failed
		ifFalse: [self
				sqSocket: s
				ConnectTo: addr
				Port: port]