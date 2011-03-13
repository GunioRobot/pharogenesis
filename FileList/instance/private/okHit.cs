okHit
	ok := true.
	currentDirectorySelected
		ifNil: [Beeper beep]
		ifNotNil: [modalView delete]