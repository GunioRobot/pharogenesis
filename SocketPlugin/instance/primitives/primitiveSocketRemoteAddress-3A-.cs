primitiveSocketRemoteAddress: socket

	| s addr |
	self var: #s declareC: 'SocketPtr s'.
	self primitive: 'primitiveSocketRemoteAddress'
		parameters: #(Oop).
	s _ self socketValueOf: socket.
	addr _ self sqSocketRemoteAddress: s.
	^self intToNetAddress: addr