primitiveSocket: socket connectTo: address port: port

	| addr s |
	self var: #s declareC: 'SocketPtr s'.
	self primitive: 'primitiveSocketConnectToPort'
		parameters: #(Oop ByteArray SmallInteger).

	addr _ self netAddressToInt: (self cCoerce: address to: 'unsigned char *').
	s _ self socketValueOf: socket.
	interpreterProxy failed ifFalse: [
		self sqSocket: s ConnectTo: addr Port: port]