scanNext
	self scanWhitespace.
	currentTokenFirst := self currentChar.
	currentTokenFirst isNil 
		ifTrue: [" end of input "
			currentTokenFirst := $ .
			currentTokenSourcePosition := nil.
			currentToken := nil.
			^nil].
	currentTokenFirst isDigit ifTrue: [^self scanNumber].
	currentTokenFirst isLetter ifTrue: [^self scanIdentifier].
	^self scanBinary