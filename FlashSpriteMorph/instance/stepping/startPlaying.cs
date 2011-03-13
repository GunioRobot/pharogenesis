startPlaying
	"Start playing from the current frame"
	playing ifTrue:[^self].
	loadedFrames = 0 ifTrue:[^nil].
	frameNumber >= maxFrames ifTrue:[self frameNumber: 1].
	playing := true.
	self playSoundsAt: frameNumber.
	self executeActionsAt: frameNumber.
	lastStepTime := Time millisecondClockValue.