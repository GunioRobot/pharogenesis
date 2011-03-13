mouseMove: evt
	"Drag our target around"
	| thePoint |
	thePoint _ target point: (evt position - positionOffset) from: owner.
	target setConstrainedPositionFrom: thePoint.