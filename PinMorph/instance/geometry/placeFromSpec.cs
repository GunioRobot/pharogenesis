placeFromSpec
	| side corners c1 c2 |
	side _ pinSpec pinLoc asInteger.  "1..4 ccw from left"
	corners _ owner bounds corners.
	c1 _ corners at: side.
	c2 _ corners atWrap: side+1.
	self position: (c1 + (c2 - c1 * pinSpec pinLoc fractionPart)).
	self updateImage.