upArrowHit
	currentIndex _ currentIndex + 1.
	(currentIndex > formChoices size) ifTrue: [currentIndex _ 1].
	self updateThumbnail
	
