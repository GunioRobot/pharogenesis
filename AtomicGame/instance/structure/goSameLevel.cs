goSameLevel
	| map |
	map _ self createSameMap.
	map
		ifNotNil: [self goLevel: map]