nextString
	| out byte |
	out _ WriteStream on: (String new: 50).
	[byte _ self nextByte.
	byte = 0] whileFalse:
		[out nextPut: (self convertChar2Squeak: byte asCharacter)].
	^out contents