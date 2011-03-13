currentFrame

	frameList isEmpty ifTrue: [^ nil].
	currentFrameIndex > frameList size
		ifTrue: [currentFrameIndex := frameList size].
	currentFrameIndex < 1
		ifTrue: [currentFrameIndex := 1].
	^ frameList at: currentFrameIndex
