internCharacter: aCharacter

	OneCharacterMultiSymbols ifNil: [^self intern: aCharacter asString].

	^ OneCharacterMultiSymbols at: aCharacter asciiValue + 1
