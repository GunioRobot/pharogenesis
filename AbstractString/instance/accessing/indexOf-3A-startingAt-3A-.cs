indexOf: aCharacter  startingAt: start

	(aCharacter class == Character) ifFalse: [^ 0].
	^ self class indexOfAscii: aCharacter asciiValue inString: self startingAt: start