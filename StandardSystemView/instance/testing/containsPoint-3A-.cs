containsPoint: aPoint 
	"Refer to the comment in View|containsPoint:."

	^(super containsPoint: aPoint) | (self labelContainsPoint: aPoint)