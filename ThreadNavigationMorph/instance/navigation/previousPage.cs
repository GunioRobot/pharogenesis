previousPage

	self currentIndex <= 1 ifTrue: [^Beeper beep].
	currentIndex _ self currentIndex - 1.
	self loadPageWithProgress.