primitiveResolverStartAddressLookup

	| addr |
	addr _ self netAddressToInt: self stackTop.
	successFlag ifTrue: [
		self sqResolverStartAddrLookup: addr.
	].
	successFlag ifTrue: [
		self pop: 1.  "pop addr, leave rcvr on stack"
	].