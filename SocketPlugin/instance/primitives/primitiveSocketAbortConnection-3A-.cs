primitiveSocketAbortConnection: socket

	| s |
	self var: #s declareC: 'SocketPtr s'.
	self primitive: 'primitiveSocketAbortConnection'
		parameters: #(Oop).
	s _ self socketValueOf: socket.
	interpreterProxy failed ifFalse: [
		self sqSocketAbortConnection: s]