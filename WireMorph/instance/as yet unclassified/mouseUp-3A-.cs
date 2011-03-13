mouseUp: evt
	handles == nil
		ifTrue: [self addHandles]
		ifFalse: [self removeHandles]