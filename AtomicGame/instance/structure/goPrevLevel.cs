goPrevLevel
	| map |
	map _ self createPrevMap.
	map
		ifNotNil: [self goLevel: map]