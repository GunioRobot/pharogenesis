okHit
	ok _ true.
	currentDirectorySelected
		ifNil: [Beeper beep]
		ifNotNil: [modalView delete]