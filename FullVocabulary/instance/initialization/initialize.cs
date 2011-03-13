initialize
	"Initialize the receiver (automatically called when instances are created via 'new')
Vocabulary initialize
"

	super initialize.
	vocabularyName _ #Full.
	self documentation: '"Full" is all-encompassing vocabulary that embraces all methods understood by an object'.
	self rigAFewCategories