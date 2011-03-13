contentString: aString
	aString == nil
		ifTrue:[self removeProperty: #contentString]
		ifFalse:[self setProperty: #contentString toValue: aString]