previousPage

	self currentIndex <= 1 ifTrue: [^1 beep].
	currentIndex _ self currentIndex - 1.
	self loadPageWithProgress.