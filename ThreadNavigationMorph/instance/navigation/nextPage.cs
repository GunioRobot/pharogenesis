nextPage

	self currentIndex >= listOfPages size ifTrue: [^Beeper beep].
	currentIndex _ self currentIndex + 1.
	self loadPageWithProgress.