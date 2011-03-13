playArrivalSound

	Preferences soundsEnabled ifTrue: [
		SampledSound playSoundNamed: 'chirp'.
	] ifFalse: [
		1 beep
	].