hasProperty: propName
	"Answer whether the receiver has the given property.  Deemed to have it only if I have a property dictionary entry for it and that entry is neither nil nor false"
	self valueOfProperty: propName ifAbsent:[^false].
	^true