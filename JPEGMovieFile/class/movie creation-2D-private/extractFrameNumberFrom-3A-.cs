extractFrameNumberFrom: aString
	"Answer the integer frame number from the given file name string. The frame number is assumed to be the last contiguous sequence of digits in the given string. For example, 'take2 005.jpg' is frame 5 of the sequence 'take2'."
	"Assume: The given string contains at least one digit."

	| end start |
	end _ aString size.
	[(aString at: end) isDigit not] whileTrue: [end _ end - 1].
	start _ end.
	[(start > 1) and: [(aString at: start - 1) isDigit]] whileTrue: [start _ start - 1].
	^ (aString copyFrom: start to: end) asNumber
