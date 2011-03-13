value: code

	| l |
	code < 256 ifTrue: [^ Character value: code].
	l := Locale currentPlatform languageEnvironment leadingChar.
	l = 0 ifTrue: [l := 255].
	^ Character leadingChar: l code: code.
