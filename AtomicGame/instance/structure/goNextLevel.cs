goNextLevel
	| map |
	map _ self createNextMap.
	map
		ifNotNil: [self goLevel: map]