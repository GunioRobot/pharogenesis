forParagraph: aParagraph
	"Initialize the receiver for scanning the given paragraph."

	self
		initializeFromParagraph: aParagraph
		clippedBy: aParagraph clippingRectangle.
