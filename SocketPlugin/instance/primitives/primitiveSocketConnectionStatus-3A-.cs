primitiveSocketConnectionStatus: socket

	| s status |
	self var: #s declareC: 'SocketPtr s'.
	self primitive: 'primitiveSocketConnectionStatus'
		parameters: #(Oop).
	s _ self socketValueOf: socket.
	interpreterProxy failed ifFalse: [
		status _ self sqSocketConnectionStatus: s].
	^ status asSmallIntegerObj