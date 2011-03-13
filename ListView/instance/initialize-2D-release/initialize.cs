initialize 
	"Refer to the comment in View|initialize."

	super initialize.
	topDelimiter _ '------------'.
	bottomDelimiter _ '------------'.
	lineSpacing _ 0.
	isEmpty _ true.
	self list: Array new