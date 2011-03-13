minHeight: aNumber
	aNumber == nil
		ifTrue:[self removeProperty: #minHeight]
		ifFalse:[self setProperty: #minHeight toValue: aNumber].
	self layoutChanged.