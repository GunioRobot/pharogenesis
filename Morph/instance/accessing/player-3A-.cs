player: anObject
	extension == nil ifTrue: [self assureExtension].
	extension player: anObject