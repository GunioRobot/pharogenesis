addSound: aSound forState: state
	sounds ifNil:[sounds := Dictionary new].
	sounds at: state put: aSound.