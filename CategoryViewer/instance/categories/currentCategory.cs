currentCategory
	"Answer the symbol representing the receiver's currently-selected category"

	| current |
	current _ namePane renderedMorph firstSubmorph contents.
	^ current ifNotNil: [current asSymbol] ifNil: [#basic]