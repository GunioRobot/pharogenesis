extent: aPoint
	"Round to a number divisible by grid.  Note that the superclass has its own implementation."
	| g gridSize |
	gridSize _ self gridSizeFor: aPoint.
	"self halt."
	g _ (aPoint - (2 * borderWidth)) // gridSize.
	srcExtent _ g * gridSize.
	gridNum _ g.
	^super extent: self defaultExtent