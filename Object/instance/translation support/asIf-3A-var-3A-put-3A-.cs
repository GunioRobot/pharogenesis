asIf: aClass var: aString put: aValue

	|index|
	index _ aClass allInstVarNames 
		indexOf: aString
		ifAbsent: [self error: 'must use instVar name'].
	^self instVarAt: index put: aValue
