primitiveSocketLocalPort: socket

	| s port |
	self var: #s declareC: 'SocketPtr s'.
	self primitive: 'primitiveSocketLocalPort'
		parameters: #(Oop).
	s _ self socketValueOf: socket.
	port _ self sqSocketLocalPort: s.
	^port asSmallIntegerObj