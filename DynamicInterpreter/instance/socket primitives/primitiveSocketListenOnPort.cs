primitiveSocketListenOnPort

	| port s |
	self var: #s declareC: 'SocketPtr s'.
	port _ self stackIntegerValue: 0.
	s _ self socketValueOf: (self stackValue: 1).
	successFlag ifTrue: [
		self sqSocket: s ListenOnPort: port.
	].
	successFlag ifTrue: [
		self pop: 2.  "pop s, port; leave rcvr on stack"
	].
