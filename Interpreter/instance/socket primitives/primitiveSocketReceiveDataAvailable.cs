primitiveSocketReceiveDataAvailable

	| s dataIsAvailable |
	self var: #s declareC: 'SocketPtr s'.
	s _ self socketValueOf: self stackTop.
	successFlag ifTrue: [
		dataIsAvailable _ self sqSocketReceiveDataAvailable: s.
	].
	successFlag ifTrue: [
		self pop: 2.  "pop s, rcvr"
		self pushBool: dataIsAvailable.
	].
