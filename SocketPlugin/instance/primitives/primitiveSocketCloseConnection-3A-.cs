primitiveSocketCloseConnection: socket

	| s |
	self var: #s declareC: 'SocketPtr s'.
	self primitive: 'primitiveSocketCloseConnection'
		parameters: #(Oop).
	s _ self socketValueOf: socket.
	interpreterProxy failed ifFalse: [
		self sqSocketCloseConnection: s]