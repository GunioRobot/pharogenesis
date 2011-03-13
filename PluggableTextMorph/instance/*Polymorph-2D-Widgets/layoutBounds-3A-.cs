layoutBounds: aRectangle
	"Set the bounds for laying out children of the receiver.
	Note: written so that #layoutBounds can be changed without touching this method"
	
	super layoutBounds: aRectangle.
	textMorph ifNotNil:
		[textMorph extent: (self innerBounds width-6)@self height].
	self setScrollDeltas
