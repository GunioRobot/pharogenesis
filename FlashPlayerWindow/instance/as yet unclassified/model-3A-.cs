model: aFlashPlayerModel
	aFlashPlayerModel isStreaming
		ifTrue:[self addProgressIndicator: aFlashPlayerModel progressValue].
	^super model: aFlashPlayerModel