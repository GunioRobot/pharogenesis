center: aPoint
	"Set the point at the center of the receiver.  Leave extent the same."

	self moveBy: (aPoint - self center)