currentFrame

	frameList isEmpty ifTrue: [^ nil].
	currentFrameIndex > frameList size
		ifTrue: [currentFrameIndex _ frameList size].
	currentFrameIndex < 1
		ifTrue: [currentFrameIndex _ 1].
	^ frameList at: currentFrameIndex
