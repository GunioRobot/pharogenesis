primitiveInitializeNetwork

	| resolverSemaIndex err |
	resolverSemaIndex _ self stackIntegerValue: 0.
	successFlag ifTrue: [
		err _ self sqNetworkInit: resolverSemaIndex.
		self success: err = 0.
	].
	successFlag ifTrue: [
		self pop: 1.  "pop resolverSemaIndex, leave rcvr on stack"
	].