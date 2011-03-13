doControl

	currentIndex > 0 ifTrue: [
		(sounds at: currentIndex) doControl.
	].
