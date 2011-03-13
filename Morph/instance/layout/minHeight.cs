minHeight
	extension == nil ifTrue:[^2].
	^self valueOfProperty: #minHeight ifAbsent:[2]