primitiveSocketError: socket

	| s err |
	self var: #s declareC: 'SocketPtr s'.
	self primitive: 'primitiveSocketError'
		parameters: #(Oop).
	s _ self socketValueOf: socket.
	interpreterProxy failed ifFalse: [
		err _ self sqSocketError: s].
	^err asSmallIntegerObj