primitiveSocketRemotePort

	| s port |
	self var: #s declareC: 'SocketPtr s'.
	s _ self socketValueOf: self stackTop.
	successFlag ifTrue: [
		port _ self sqSocketRemotePort: s.
	].
	successFlag ifTrue: [
		self pop: 2 thenPush: (self integerObjectOf: port).
	].
