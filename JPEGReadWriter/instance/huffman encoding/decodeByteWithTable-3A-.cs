decodeByteWithTable: aHuffmanTable

	| look nb length code |
	look _ self peekBits: lookahead.
	(look >= 0 and: [(nb _ aHuffmanTable lookaheadBits at: look+1) ~= 0])
		ifTrue:
			[self getBits: nb.
			^ aHuffmanTable lookaheadSymbol at: look+1].
	length _ 1.
	code _ self getBits: length.
	[code > (aHuffmanTable maxcode at: length)] whileTrue:
		[code _ code << 1 + (self getBits: 1).
		length _ length + 1].
	length > 16 ifTrue: [self error: 'bad encoding value in bit stream'].
	^ aHuffmanTable valueForCode: code length: length.
				