fit
	"Make the bounding rectangle of the paragraph contain all the text while 
	 not changing the width of the view of the paragraph.  No effect on undoability
	 of the preceding command."

	paragraph clearVisibleRectangle.
	paragraph fit.
	paragraph displayOn: Display; outline.
	self recomputeInterval