isFrameLoaded: frame elseSkip: nActions
	"Skip nActions if the given frame is not loaded yet."
	^loadedFrames >= frameNumber 
		ifTrue:[nil]
		ifFalse:[nActions].