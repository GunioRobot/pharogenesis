internCharacter: aCharacter

	OneCharacterSymbols ifNil: [^self intern: aCharacter asString].

	^OneCharacterSymbols at: aCharacter asciiValue + 1
