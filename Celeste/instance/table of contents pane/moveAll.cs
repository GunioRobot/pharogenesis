moveAll
	"Move all visible messages in the current category to another category."

	| newCatName |
	mailDB ifNil: [ ^self ].
	newCatName _ self getCategoryNameIfNone: [^self].
	newCatName = self category ifTrue:[ ^self ].
	mailDB fileAll: currentMessages inCategory: newCatName.

	self removeAll.