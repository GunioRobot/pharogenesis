fromJISX0208String: aString

	^ aString collect: [:each | MultiCharacter leadingChar: JapaneseEnvironment leadingChar code: (each asUnicode)].
