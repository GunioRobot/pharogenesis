lastPage

	listOfPages isEmpty ifTrue: [^Beeper beep].
	currentIndex _ listOfPages size.
	self loadPageWithProgress.