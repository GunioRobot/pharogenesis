primitiveResponse
	primitiveIndex > MaxPrimitiveIndex ifTrue: [^ false].
	successFlag _ true.
	self dispatchOn: primitiveIndex in: PrimitiveTable.
	"check for possible timer interrupts after each primitive"
	(successFlag and:
	 [(nextWakeupTick ~= 0) and:
	 [self ioMSecs >= nextWakeupTick]]) ifTrue: [
		interruptCheckCounter _ 1000.
		self checkForInterrupts].
	^ successFlag