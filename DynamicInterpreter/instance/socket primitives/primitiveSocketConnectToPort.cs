primitiveSocketConnectToPort

	| port addr s |
	self var: #s declareC: 'SocketPtr s'.
	port _ self stackIntegerValue: 0.
	addr _ self netAddressToInt: (self stackValue: 1).
	s _ self socketValueOf: (self stackValue: 2).
	successFlag ifTrue: [
		self sqSocket: s ConnectTo: addr Port: port.
	].
	successFlag ifTrue: [
		self pop: 3.  "pop s, addr, port; leave rcvr on stack"
	].
