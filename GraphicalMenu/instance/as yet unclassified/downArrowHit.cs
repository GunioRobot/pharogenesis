downArrowHit
	currentIndex _ currentIndex - 1.
	(currentIndex < 1) ifTrue:  [currentIndex _ formChoices size].
	self updateThumbnail
	
