borderWidth: anInteger
	"Grow outwards preserving innerBounds"
	| c |  
	c _ self center.
	super borderWidth: anInteger.
	super extent: self defaultExtent.
	self center: c.