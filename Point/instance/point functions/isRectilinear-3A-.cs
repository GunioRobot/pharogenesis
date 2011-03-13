isRectilinear: aPoint

	"Answer true if a line between the receiver and aPoint is either vertical or horizontal, else false"

	^ (x == aPoint x) | (y == aPoint y)