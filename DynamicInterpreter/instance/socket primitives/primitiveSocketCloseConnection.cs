primitiveSocketCloseConnection

	| s |
	self var: #s declareC: 'SocketPtr s'.
	s _ self socketValueOf: self stackTop.
	successFlag ifTrue: [
		self sqSocketCloseConnection: s.
	].
	successFlag ifTrue: [
		self pop: 1.  "pop s; leave rcvr on stack"
	].
