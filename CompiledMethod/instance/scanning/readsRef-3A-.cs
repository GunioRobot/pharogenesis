readsRef: literalAssociation 
	"Answer whether the receiver loads the argument."
	| lit |
	lit _ self literals indexOf: literalAssociation ifAbsent: [^false].
	lit <= 32 ifTrue: [^self scanFor: 64 + lit - 1].
	lit <= 64 ifTrue: [^self scanLongLoad: 192 + lit - 1].
	^ self scanVeryLongLoad: 128 offset: lit - 1