previousPage
	playDirection = 0 ifFalse: [^ self]. "No-op during play"
	self goToPage: (frameNumber := frameNumber - 1 max: 1).
