initialize
	"Initialize the receiver (automatically called when instances are created via 'new')
Vocabulary initialize
"

	super initialize.
	vocabularyName _ #Object.
	self documentation: '"Object" is all-encompassing vocabulary that embraces all methods understood by an object'.
	self rigAFewCategories