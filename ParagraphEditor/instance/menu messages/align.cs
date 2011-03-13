align
	"Align text according to the next greater alignment value--cycling among 
	left flush, right flush, center, justified.  No effect on the undoability of the pre
	preceding command."

	paragraph toggleAlignment.
	paragraph displayOn: Display.
	self recomputeInterval