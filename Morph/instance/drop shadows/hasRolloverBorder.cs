hasRolloverBorder
	extension == nil ifTrue:[^false].
	^self valueOfProperty: #hasRolloverBorder ifAbsent:[false]