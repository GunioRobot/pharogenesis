defaultAALevel: aNumber
	aNumber isNil 
		ifTrue:[self removeProperty: #aaLevel]
		ifFalse:[self setProperty: #aaLevel toValue: aNumber]