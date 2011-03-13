firstPage

	listOfPages isEmpty ifTrue: [^1 beep].
	currentIndex _ 1.
	self loadPageWithProgress.