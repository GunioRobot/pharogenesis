primitiveSocketDestroy

	| s |
	self var: #s declareC: 'SocketPtr s'.
	s _ self socketValueOf: self stackTop.
	successFlag ifTrue: [
		self sqSocketDestroy: s.
	].
	successFlag ifTrue: [
		self pop: 1.  "pop s; leave rcvr on stack"
	].
