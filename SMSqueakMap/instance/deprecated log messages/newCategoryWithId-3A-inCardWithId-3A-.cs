newCategoryWithId: catIdString inCardWithId: cardIdString
	"Deprecated. Add a category to a card.
	Only kept for converting old log. We add all categories
	to the package (as before) and not the release. "

	^self newCategoryWithId: catIdString inObjectWithId: cardIdString
