angle: newAngle

	self changed.
	transform _ transform withAngle: newAngle.
	self layoutChanged.
	self changed