placeFromSpec
	| side corners c1 c2 pos |
	side _ pinSpec pinLoc asInteger.  "1..4 ccw from left"
	corners _ owner bounds corners.
	c1 _ corners at: side.
	c2 _ corners atWrap: side+1.
	pos _ c1 + (c2 - c1 * pinSpec pinLoc fractionPart) grid: 4@4.
	side = 1 ifTrue: [super position: pos - (8@0)].
	(side = 2) | (side = 3) ifTrue: [super position: pos].
	side = 4 ifTrue: [super position: pos - (0@8)].
	self updateImage.