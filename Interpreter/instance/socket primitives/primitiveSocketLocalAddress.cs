primitiveSocketLocalAddress

	| s addr |
	self var: #s declareC: 'SocketPtr s'.
	s _ self socketValueOf: self stackTop.
	successFlag ifTrue: [
		addr _ self sqSocketLocalAddress: s.
	].
	successFlag ifTrue: [
		self pop: 2 thenPush: (self intToNetAddress: addr).
	].
