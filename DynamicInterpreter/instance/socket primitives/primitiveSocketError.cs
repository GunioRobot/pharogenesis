primitiveSocketError

	| s err |
	self var: #s declareC: 'SocketPtr s'.
	s _ self socketValueOf: self stackTop.
	successFlag ifTrue: [
		err _ self sqSocketError: s.
	].
	successFlag ifTrue: [
		self pop: 2 thenPush: (self integerObjectOf: err).
	].
