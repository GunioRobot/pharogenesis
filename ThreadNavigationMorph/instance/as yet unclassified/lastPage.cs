lastPage

	listOfPages isEmpty ifTrue: [^1 beep].
	currentIndex _ listOfPages size.
	self loadPageWithProgress.