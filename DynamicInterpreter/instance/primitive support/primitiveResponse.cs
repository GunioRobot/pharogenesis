primitiveResponse
	self inline: false.
	primitiveIndex > MaxPrimitiveIndex ifTrue: [^ false].
	successFlag _ true.
	self dispatchOn: primitiveIndex in: PrimitiveTable.
	"check for possible timer interrupts after each primitive"
	(successFlag and:
	 [(nextWakeupTick ~= 0) and:
	 [(self ioMSecs bitAnd: 16r1FFFFFFF) >= nextWakeupTick]]) ifTrue: [
		interruptCheckCounter _ 1000.
		self checkForInterrupts].
	^ successFlag