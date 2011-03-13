defaultAction
	Smalltalk isMorphic
		ifTrue: [self defaultMorphicAction]
		ifFalse: [self defaultMVCAction].
