rotationDegrees: newRotationDegrees scalePoint: newScalePoint

	((newRotationDegrees ~= rotationDegrees) or:
	 [scalePoint ~= newScalePoint]) ifTrue: [
		"rotationDegrees _ newRotationDegrees \\ 360.0."
		rotationDegrees _ newRotationDegrees asSmallAngleDegrees.
		scalePoint _ newScalePoint.
		self layoutChanged].
