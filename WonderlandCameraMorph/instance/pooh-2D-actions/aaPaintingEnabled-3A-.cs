aaPaintingEnabled: aBool
	aBool
		ifTrue:[self removeProperty: #aaPaintingEnabled]
		ifFalse:[self setProperty: #aaPaintingEnabled toValue: aBool]