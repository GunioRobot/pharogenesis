goToPage: i
	currentPage ifNil: [self makeMyPage].
	frameNumber _ i.
	playDirection _ 0.
	self startRunning; step  "will stop after first step"
