doDrag: evt with: dragHandle
	| thePoint |
	evt hand obtainHalo: self.
	thePoint _ target point: evt position - positionOffset from: owner.
	target setConstrainedPositionFrom:(target griddedPoint: thePoint).
