addSound: aSound forState: state
	sounds ifNil:[sounds _ Dictionary new].
	sounds at: state put: aSound.