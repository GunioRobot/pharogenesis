selectTabNamed: aName
	| aTab |
	aTab _ self tabMorphs detect: [:m | ((m isKindOf: StringMorph) and: [m contents = aName])
		or: [(m isKindOf: ReferenceMorph) and: [(m firstSubmorph isKindOf: StringMorph) and:
				[m firstSubmorph contents = aName]]]] ifNone: [nil].
	aTab ifNotNil: [self selectTab: aTab]