nextPage
	playDirection = 0 ifFalse: [^ self]. "No-op during play"
	self goToPage: (frameNumber _ frameNumber + 1 min: frameCount).
