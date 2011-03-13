xSingleQuote
	"String."

	self step.
	buffer reset.
	[hereChar = $' 
		and: [aheadChar = $' 
				ifTrue: [self step. false]
				ifFalse: [true]]]
		whileFalse: 
			[buffer nextPut: self step.
			(hereChar = 30 asCharacter and: [source atEnd])
				ifTrue: [^self offEnd: 'Unmatched string quote']].
	self step.
	token := buffer contents.
	tokenType := #string