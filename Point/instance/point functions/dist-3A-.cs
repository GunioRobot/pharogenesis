dist: aPoint 
	"Answer the distance between aPoint and the receiver."

	| dx dy |

	dx _ aPoint x - x.
	dy _ aPoint y - y.

	^ ((dx * dx) + (dy * dy)) sqrt