scanIdentifier
	| c start |
	start := sourcePosition.
	[(c := self nextChar) isAlphaNumeric] whileTrue: [].
	(c = $: and: [(self isSelectorCharacter: self peekChar) not]) 
		ifTrue: [self nextChar].
	currentToken := source copyFrom: start to: sourcePosition - 1.
	currentTokenSourcePosition := start