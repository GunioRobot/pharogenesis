setFrame: newFrameIndex

	| oldFrame p newFrame |
	oldFrame _ self currentFrame.
	oldFrame ifNil: [^ self].

	self changed.
	p _ oldFrame referencePosition.
	currentFrameIndex _ newFrameIndex.
	currentFrameIndex > frameList size
		ifTrue: [currentFrameIndex _ frameList size].
	currentFrameIndex < 1
		ifTrue: [currentFrameIndex _ 1].
	newFrame _ frameList at: currentFrameIndex.
	newFrame referencePosition: p.
	oldFrame delete.
	self addMorph: newFrame.
	dwellCount _ newFrame framesToDwell.
	self layoutChanged.
	self changed.
