storeAndPopReceiverVariableBytecode
	"Note: This code uses 
	storePointerUnchecked:ofObject:withValue: and does the 
	store check explicitely in order to help the translator 
	produce better code."
	| rcvr top |
	self fetchNextBytecode.
	"this bytecode will be expanded so that refs to 
	currentBytecode below will be constant"
	rcvr _ receiver.
	top _ self internalStackTop.
	rcvr < youngStart
		ifTrue: [self possibleRootStoreInto: rcvr value: top].
	self storePointerUnchecked: (currentBytecode bitAnd: 7) ofObject: rcvr withValue: top.
	self internalPop: 1