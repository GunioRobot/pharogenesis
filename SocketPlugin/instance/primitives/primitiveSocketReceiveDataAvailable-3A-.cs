primitiveSocketReceiveDataAvailable: socket

	| s dataIsAvailable |
	self var: #s declareC: 'SocketPtr s'.
	self primitive: 'primitiveSocketReceiveDataAvailable'
		parameters: #(Oop).
	s _ self socketValueOf: socket.
	dataIsAvailable _ self sqSocketReceiveDataAvailable: s.
	^dataIsAvailable asBooleanObj