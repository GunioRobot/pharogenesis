nextBits: n
	| bits |
	[bitPos < n] whileTrue:[
		bitBuf _ bitBuf + (self nextByte bitShift: bitPos).
		bitPos _ bitPos + 8].
	bits _ bitBuf bitAnd: (1 bitShift: n)-1.
	bitBuf _ bitBuf bitShift: 0 - n.
	bitPos _ bitPos - n.
	^bits