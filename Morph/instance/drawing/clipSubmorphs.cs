clipSubmorphs
	"Drawing specific. If this property is set, clip the receiver's submorphs to the receiver's clipping bounds."
	extension == nil ifTrue:[^false]. "get out quickly"
	^self valueOfProperty: #clipSubmorphs ifAbsent:[false].