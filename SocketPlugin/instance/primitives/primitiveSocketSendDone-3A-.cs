primitiveSocketSendDone: socket

	| s done |
	self var: #s declareC: 'SocketPtr s'.
	self primitive: 'primitiveSocketSendDone'
		parameters: #(Oop).
	s _ self socketValueOf: socket.
	done _ self sqSocketSendDone: s.
	^done asBooleanObj