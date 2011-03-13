minWidth
	extension == nil ifTrue:[^2].
	^self valueOfProperty: #minWidth ifAbsent:[2]