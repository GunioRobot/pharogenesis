hasDropShadow
	extension == nil ifTrue:[^false].
	^self valueOfProperty: #hasDropShadow ifAbsent:[false]