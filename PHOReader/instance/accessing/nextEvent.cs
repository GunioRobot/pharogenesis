nextEvent
	| line phonemeName phoneme duration answer ptime pitch |
	line _ ReadStream on: stream nextLine.
	phonemeName _ line upTo: Character space.
	phoneme _ phonemes at: phonemeName.
	[line peek isSeparator] whileTrue: [line next].
	duration _ (line upTo: Character space) asNumber / 1000.0.
	answer _ PhoneticEvent new phoneme: phoneme; duration: duration; loudness: 1.0.
	[line atEnd]
		whileFalse: [ptime _ (line upTo: Character space) asNumber * duration / 100.0.
					pitch _ (line upTo: Character space) asNumber asFloat.
					pitches add: time + ptime @ pitch].
	time _ time + duration.
	^ answer