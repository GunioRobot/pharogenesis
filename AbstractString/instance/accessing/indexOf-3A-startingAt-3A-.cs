indexOf: aCharacter  startingAt: start

	(aCharacter class == Character) ifFalse: [^ 0].
	^ String indexOfAscii: aCharacter asciiValue inString: self startingAt: start