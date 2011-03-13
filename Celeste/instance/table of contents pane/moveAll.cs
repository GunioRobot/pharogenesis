moveAll
	"Move all visible messages in the current category to another category."

	| newCatName |
	newCatName _ self getCategoryNameIfNone: [^self].
	newCatName = currentCategory ifTrue:[ ^self ].
	mailDB fileAll: currentMessages inCategory: newCatName.

	self removeAll.