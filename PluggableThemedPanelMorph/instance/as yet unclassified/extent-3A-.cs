extent: aPoint
	"Update the bar fillStyle if appropriate."
	
	super extent: aPoint.
	self fillStyle isOrientedFill ifTrue: [
		self fillStyle: self normalFillStyle]