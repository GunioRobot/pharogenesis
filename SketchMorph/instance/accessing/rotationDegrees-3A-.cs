rotationDegrees: angleInDegrees

	rotationDegrees ~= angleInDegrees ifTrue:
		[rotationDegrees _ angleInDegrees asSmallAngleDegrees.
		self layoutChanged].
