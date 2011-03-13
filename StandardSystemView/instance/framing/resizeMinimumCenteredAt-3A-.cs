resizeMinimumCenteredAt: aPoint 
	"Determine the rectangular area for the receiver, adjusted so that it is 
	centered a position, aPoint."
	| aRectangle |
	aRectangle := 0 @ 0 extent: self minimumSize.
	aRectangle := aRectangle align: aRectangle center with: aPoint.
	self resizeTo: aRectangle