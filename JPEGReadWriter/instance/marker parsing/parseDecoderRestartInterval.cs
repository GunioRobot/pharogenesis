parseDecoderRestartInterval

	| length |
	length _ self nextWord.
	length = 4 ifFalse: [self error: 'DRI length incorrect'].
	restartInterval _ self nextWord.