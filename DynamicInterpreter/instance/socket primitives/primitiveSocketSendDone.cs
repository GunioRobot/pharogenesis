primitiveSocketSendDone

	| s done |
	self var: #s declareC: 'SocketPtr s'.
	s _ self socketValueOf: self stackTop.
	successFlag ifTrue: [
		done _ self sqSocketSendDone: s.
	].
	successFlag ifTrue: [
		self pop: 2.  "pop s, rcvr"
		self pushBool: done.
	].
