stepForward
	frameNumber < maxFrames
		ifTrue:[^self frameNumber: frameNumber + 1].
	self loopFrames
		ifTrue:[self frameNumber: 1]
		ifFalse:[self stopPlaying].