toUnicode: aChar

	^ MultiCharacter leadingChar: JapaneseEnvironment leadingChar code: aChar asUnicode.
