nextPage

	self currentIndex >= listOfPages size ifTrue: [^1 beep].
	currentIndex _ self currentIndex + 1.
	self loadPageWithProgress.