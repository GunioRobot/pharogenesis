primitiveSocketConnectionStatus

	| s status |
	self var: #s declareC: 'SocketPtr s'.
	s _ self socketValueOf: self stackTop.
	successFlag ifTrue: [
		status _ self sqSocketConnectionStatus: s.
	].
	successFlag ifTrue: [
		self pop: 2 thenPush: (self integerObjectOf: status).
	].
