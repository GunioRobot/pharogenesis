storeAndPopReceiverVariable: fieldIndex
	"Note: This code uses storePointerUnchecked:ofObject:withValue: and does the store check explicitly in order to help the translator produce better code."

	| rcvr top |
	rcvr _ self internalReceiver.
	top _ self internalStackTop.
	(rcvr < youngStart) ifTrue: [
		self possibleRootStoreInto: rcvr value: top.
	].
	self storePointerUnchecked: (fieldIndex)
		ofObject: rcvr
		withValue: top.
	self internalPop: 1.
