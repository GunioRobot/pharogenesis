reportLastMatch
	"The scanner has found the end of a token and must report it"

	| string |
	self checkForValidMatch.
	self resetOutputToLastMatch.
	stream position: matchEnd.
	string := outputStream contents.
	self checkForKeyword: string.
	matchActions isSymbol 
		ifTrue: [self perform: matchActions]
		ifFalse: [self createTokenFor: string]