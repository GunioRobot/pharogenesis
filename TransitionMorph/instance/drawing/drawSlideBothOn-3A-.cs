drawSlideBothOn: aCanvas
	"endMorph slides in the given direction, as startMorph slides out of its way."
	| endLoc endRect startLoc |
	startLoc _ self stepFrom: self position to: self position + (self extent * direction).
	aCanvas drawImage: startForm at: startLoc.

	endLoc _ self stepFrom: self position - (self extent * direction) to: self position.
	aCanvas drawImage: endForm at: endLoc.

	endRect _ endForm boundingBox translateBy: endLoc.
	((endRect translateBy: direction) areasOutside: endRect) do:
		[:r | aCanvas fillRectangle: r color: Color black].
