initialize 
	"Refer to the comment in View|initialize."

	super initialize.
	topDelimiter := '------------'.
	bottomDelimiter := '------------'.
	isEmpty := true.
	self list: Array new