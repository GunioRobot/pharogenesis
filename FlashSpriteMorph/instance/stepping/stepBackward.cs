stepBackward
	frameNumber > 1
		ifTrue:[self frameNumber: frameNumber - 1]
		ifFalse:[self frameNumber: loadedFrames].