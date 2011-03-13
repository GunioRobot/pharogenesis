scrollToBottom
	"Scroll so that the tail end of the text is visible in the view.  5/6/96 sw"

	self scrollView: (paragraph clippingRectangle bottom 
		- paragraph compositionRectangle bottom)