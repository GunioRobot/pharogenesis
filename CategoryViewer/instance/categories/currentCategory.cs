currentCategory
	"Answer the symbol representing the receiver's currently-selected category"

	| current actualPane |
	actualPane _ namePane renderedMorph.
	current _ (actualPane isKindOf: StringMorph)
				ifTrue:	[actualPane contents]
				ifFalse:	[actualPane firstSubmorph contents].
	^ current ifNotNil: [current asSymbol] ifNil: [#basic]