addFirstPoint
	"No points in stroke yet. Add the very first point."
	self addNextPoint.
	finalPoint _ firstPoint _ lastPoint.
	self addPoint: firstPoint position.