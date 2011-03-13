layoutFrame: aLayoutFrame
	aLayoutFrame == nil
		ifTrue:[self removeProperty: #layoutFrame]
		ifFalse:[self setProperty: #layoutFrame toValue: aLayoutFrame].
