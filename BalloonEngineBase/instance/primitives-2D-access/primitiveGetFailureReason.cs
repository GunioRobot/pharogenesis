primitiveGetFailureReason
	"Return the reason why the last operation failed."
	self export: true.	
	self inline: false.
	interpreterProxy methodArgumentCount = 0
		ifFalse:[^interpreterProxy primitiveFail].
	engine _ interpreterProxy stackObjectValue: 0.
	interpreterProxy failed ifTrue:[^nil].
	"Note -- don't call loadEngineFrom here because this will override the stopReason with Zero"
	(interpreterProxy isIntegerObject: engine) ifTrue:[^false].
	(interpreterProxy isPointers: engine) ifFalse:[^false].
	(interpreterProxy slotSizeOf: engine) < BEBalloonEngineSize ifTrue:[^false].
	(self loadWorkBufferFrom: 
		(interpreterProxy fetchPointer: BEWorkBufferIndex ofObject: engine))
			ifFalse:[^interpreterProxy primitiveFail].
	interpreterProxy pop: 1.
	interpreterProxy pushInteger: self stopReasonGet.