primitiveSocketDestroy: socket

	| s |
	self var: #s declareC: 'SocketPtr s'.
	self primitive: 'primitiveSocketDestroy'
		parameters: #(Oop).
	s _ self socketValueOf: socket.
	interpreterProxy failed ifFalse: [
		self sqSocketDestroy: s]