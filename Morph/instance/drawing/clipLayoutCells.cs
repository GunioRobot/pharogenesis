clipLayoutCells
	"Drawing/layout specific. If this property is set, clip the submorphs of the receiver by its cell bounds."
	extension == nil ifTrue:[^false].
	^self valueOfProperty: #clipLayoutCells ifAbsent:[false].