indexOf: aCharacter

	^ MultiString indexOfAscii: aCharacter asciiValue inMultiString: self startingAt: 1
