firstPage

	listOfPages isEmpty ifTrue: [^Beeper beep].
	currentIndex _ 1.
	self loadPageWithProgress.