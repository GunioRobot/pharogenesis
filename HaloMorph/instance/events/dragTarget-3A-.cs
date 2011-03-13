dragTarget: event
	"Begin dragging the target"
	| thePoint |
	thePoint _ target point: event position - positionOffset from: owner.
	target setConstrainedPositionFrom: thePoint.
	event hand newMouseFocus: self.