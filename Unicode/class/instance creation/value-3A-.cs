value: code

	| l |
	code < 256 ifTrue: [^ Character value: code].
	l _ Locale currentPlatform languageEnvironment leadingChar.
	l = 0 ifTrue: [l _ 255].
	^ MultiCharacter leadingChar: l code: code.
