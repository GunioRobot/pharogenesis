distanceTo: aPoint
	"Answer the distance from this turtle to the given point."

	^ ((x - aPoint x) squared + (y - aPoint y) squared) sqrt
