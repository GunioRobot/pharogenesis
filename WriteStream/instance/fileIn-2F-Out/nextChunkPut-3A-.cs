nextChunkPut: aString
	"Append the argument, aString, to the receiver, doubling embedded terminators."

	| i remainder terminator |
	terminator _ $!.
	remainder _ aString.
	[(i _ remainder indexOf: terminator) = 0] whileFalse:
		[self nextPutAll: (remainder copyFrom: 1 to: i).
		self nextPut: terminator.  "double imbedded terminators"
		remainder _ remainder copyFrom: i+1 to: remainder size].
	self nextPutAll: remainder; nextPut: terminator