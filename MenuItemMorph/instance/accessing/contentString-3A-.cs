contentString: aString 
	aString isNil 
		ifTrue: [self removeProperty: #contentString]
		ifFalse: [self setProperty: #contentString toValue: aString]