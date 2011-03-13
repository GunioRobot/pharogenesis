extent: aPoint
	"Update the bar fillStyle if appropriate."
	
	super extent: aPoint.
	self fillStyle isOrientedFill ifTrue: [
		self fillStyle: (UITheme current progressBarFillStyleFor: self)].
	self barFillStyle isOrientedFill ifTrue: [
		self barFillStyle: (UITheme current progressBarProgressFillStyleFor: self)]