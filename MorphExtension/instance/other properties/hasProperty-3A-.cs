hasProperty: propName
	"Answer whether the receiver has the given property.  Deemed to have it only if I have a property dictionary entry for it and that entry is neither nil nor false"
	| prop |
	otherProperties == nil ifTrue: [^ false].
	prop _ otherProperties at: propName ifAbsent: [nil].
	prop == nil ifTrue: [^ false].
	prop == false ifTrue: [^ false].
	^ true