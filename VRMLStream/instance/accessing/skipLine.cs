skipLine
	| char |
	[char := self nextChar.
	char asciiValue = 13 or:[char asciiValue = 10]] whileFalse.
