depth: d
	d = 0
		ifTrue:[self removeProperty: #depth]
		ifFalse:[self setProperty: #depth toValue: d]