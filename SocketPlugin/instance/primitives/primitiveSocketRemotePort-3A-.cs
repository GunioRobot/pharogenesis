primitiveSocketRemotePort: socket

	| s port |
	self var: #s declareC: 'SocketPtr s'.
	self primitive: 'primitiveSocketRemotePort'
		parameters: #(Oop).
	s _ self socketValueOf: socket.
	port _ self sqSocketRemotePort: s.
	^port asSmallIntegerObj