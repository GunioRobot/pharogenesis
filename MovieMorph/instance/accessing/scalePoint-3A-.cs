scalePoint: newScalePoint

	| frame |
	newScalePoint ~= scalePoint ifTrue: [
		self changed.
		scalePoint _ newScalePoint.
		frame _ self currentFrame.
		frame ifNotNil: [frame scalePoint: newScalePoint].
		self layoutChanged.
		self changed].
