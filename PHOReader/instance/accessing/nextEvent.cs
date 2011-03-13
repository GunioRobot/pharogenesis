nextEvent
	| line phonemeName phoneme duration answer ptime pitch |
	line := ReadStream on: stream nextLine.
	phonemeName := line upTo: Character space.
	phoneme := phonemes at: phonemeName.
	[line peek isSeparator] whileTrue: [line next].
	duration := (line upTo: Character space) asNumber / 1000.0.
	answer := PhoneticEvent new phoneme: phoneme; duration: duration; loudness: 1.0.
	[line atEnd]
		whileFalse: [ptime := (line upTo: Character space) asNumber * duration / 100.0.
					pitch := (line upTo: Character space) asNumber asFloat.
					pitches add: time + ptime @ pitch].
	time := time + duration.
	^ answer