mouseUp: evt 
	handles isNil ifTrue: [self addHandles] ifFalse: [self removeHandles]