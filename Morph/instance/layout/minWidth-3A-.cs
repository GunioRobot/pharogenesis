minWidth: aNumber
	aNumber == nil
		ifTrue:[self removeProperty: #minWidth]
		ifFalse:[self setProperty: #minWidth toValue: aNumber].
	self layoutChanged.