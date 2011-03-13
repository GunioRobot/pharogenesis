soundsEnabled
	^ self presenter ifNotNil: [self presenter soundsEnabled] ifNil: [true]