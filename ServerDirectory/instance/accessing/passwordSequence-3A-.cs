passwordSequence: aNumber

	passwordHolder ifNil: [passwordHolder _ Password new].
	passwordHolder sequence: aNumber