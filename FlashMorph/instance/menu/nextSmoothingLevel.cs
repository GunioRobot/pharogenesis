nextSmoothingLevel
	| aaLevel |
	aaLevel := self defaultAALevel ifNil:[1].
	aaLevel = 1 ifTrue:[self defaultAALevel: 2].
	aaLevel = 2 ifTrue:[self defaultAALevel: 4].
	aaLevel = 4 ifTrue:[self defaultAALevel: nil].
	self changed.