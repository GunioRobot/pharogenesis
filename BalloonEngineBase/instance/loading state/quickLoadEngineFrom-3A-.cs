quickLoadEngineFrom: engineOop
	"Load the minimal required state from the engineOop, e.g., just the work buffer."
	self inline: false.
	interpreterProxy failed ifTrue:[^false].
	(interpreterProxy isIntegerObject: engineOop) ifTrue:[^false].
	(interpreterProxy isPointers: engineOop) ifFalse:[^false].
	(interpreterProxy slotSizeOf: engineOop) < BEBalloonEngineSize ifTrue:[^false].
	engine _ engineOop.
	(self loadWorkBufferFrom: 
		(interpreterProxy fetchPointer: BEWorkBufferIndex ofObject: engineOop))
			ifFalse:[^false].
	self stopReasonPut: 0.
	objUsed _ self objUsedGet.
	engineStopped _ false.
	^true