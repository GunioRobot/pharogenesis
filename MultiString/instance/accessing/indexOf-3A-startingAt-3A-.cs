indexOf: aCharacter startingAt: start

	^ MultiString indexOfAscii: aCharacter asciiValue inMultiString: self startingAt: start.
