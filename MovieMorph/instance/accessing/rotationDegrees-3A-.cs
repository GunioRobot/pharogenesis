rotationDegrees: newRotationDegrees

	| frame |
	newRotationDegrees ~= rotationDegrees ifTrue: [
		self changed.
		rotationDegrees _ newRotationDegrees.
		frame _ self currentFrame.
		frame ifNotNil: [frame rotationDegrees: newRotationDegrees].
		self layoutChanged.
		self changed].
