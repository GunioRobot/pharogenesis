primitiveSocketLocalAddress: socket

	| s addr |
	self var: #s declareC: 'SocketPtr s'.
	self primitive: 'primitiveSocketLocalAddress'
		parameters: #(Oop).
	s _ self socketValueOf: socket.
	addr _ self sqSocketLocalAddress: s.
	^self intToNetAddress: addr