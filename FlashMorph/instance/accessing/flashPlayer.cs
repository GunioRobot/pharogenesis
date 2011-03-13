flashPlayer
	^ self firstOwnerSuchThat: [:parent | parent isFlashMorph and: [parent isFlashPlayer]]