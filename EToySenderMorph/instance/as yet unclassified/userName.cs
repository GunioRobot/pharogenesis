userName

	^ (self 
		findDeepSubmorphThat: [ :x | x isKindOf: StringMorph] 
		ifAbsent: [self halt]) contents
