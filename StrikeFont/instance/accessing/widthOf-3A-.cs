widthOf: aCharacter 
	"Answer the width of the argument as a character in the receiver."

	| ascii |
	ascii _ aCharacter asciiValue.
	(ascii between: minAscii and: maxAscii) ifFalse: [ascii _ maxAscii + 1].
	^ (xTable at: ascii + 2) - (xTable at: ascii + 1)
