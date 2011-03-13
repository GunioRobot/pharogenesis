isAsciiString

	| c |
	c _ self detect: [:each | each asciiValue > 127] ifNone: [nil].
	^ c isNil.
