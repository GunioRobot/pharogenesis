beFlap: aBool
	aBool
		ifTrue:[self setProperty: #flap toValue: true]
		ifFalse:[self removeProperty: #flap]