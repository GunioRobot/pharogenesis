getCategoryNameIfNone: aBlock
	"Prompt the user for a category name"
	^self getCategoryNameAllowingAny: false  ifNone: aBlock