defaultAction
	(Smalltalk isMorphic and: [Preferences valueOfFlag: #morphicProgressStyle])
		ifTrue: [self defaultMorphicAction]
		ifFalse: [self defaultMVCAction].
