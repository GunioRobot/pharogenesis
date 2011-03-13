nextToken
	| c |
	self skipSeparators.
	c _ self peekChar.
	c ifNil: [ ^nil ].
	c = $( ifTrue: [ ^self nextComment ].
	c = $" ifTrue: [ ^self nextQuotedString ].
	c = $[ ifTrue: [ ^self nextDomainLiteral ].
	(CSSpecials includes: c) ifTrue: [ ^self nextSpecial ].
	^self nextAtom