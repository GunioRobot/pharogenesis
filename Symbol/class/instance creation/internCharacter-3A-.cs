internCharacter: aCharacter
	"Answer a unique Symbol of one character, the argument, aCharacter."

	| ascii |
	(ascii _ aCharacter asciiValue) < 128
		ifTrue: [^SingleCharSymbols at: ascii + 1].
	^self intern: (String with: aCharacter)