distanceTo: aPoint
	"Answer the distance from this patch to the given point."

	^ ((x - aPoint x) squared + (y - aPoint y) squared) sqrt
