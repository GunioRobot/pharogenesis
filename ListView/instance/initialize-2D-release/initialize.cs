initialize 
	"Refer to the comment in View|initialize."

	super initialize.
	topDelimiter _ '------------'.
	bottomDelimiter _ '------------'.
	isEmpty _ true.
	self list: Array new