writesRef: ref 
	"Answer whether the receiver stores the argument."
	| lit |
	lit _ self literals indexOf: ref ifAbsent: [^false].
	lit <= 64 ifTrue: [^ self scanLongStore: 192 + lit - 1].
	^ self scanVeryLongStore: 224 offset: lit - 1