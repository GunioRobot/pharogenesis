widthOf: aCharacter 
	"Answer the width of the argument as a character in the receiver."
	| code |
	code := aCharacter charCode.
	((code < minAscii or: [maxAscii < code]) 
		or: [(xTable at: code + 1) < 0])
			ifTrue: [^ self fallbackFont widthOf: aCharacter].
	^ (xTable at: code + 2) - (xTable at: code + 1)