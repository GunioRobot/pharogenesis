goFirstLevel
	| map |
	map _ (self createFirstMap).
	map
		ifNotNil: [self goLevel: map]