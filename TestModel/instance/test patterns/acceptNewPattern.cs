acceptNewPattern

	(Smalltalk isMorphic)
		ifTrue: [self patternTextM accept]
		ifFalse: [self patternTextV controller accept].