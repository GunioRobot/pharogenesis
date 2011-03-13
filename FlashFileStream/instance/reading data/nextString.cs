nextString
	| out byte |
	out := WriteStream on: (String new: 50).
	[byte := self nextByte.
	byte = 0] whileFalse:
		[out nextPut: (self convertChar2Squeak: byte asCharacter)].
	^out contents