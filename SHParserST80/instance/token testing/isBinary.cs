isBinary
	(currentToken isNil or: [self isName or: [self isKeyword]]) 
		ifTrue: [^false].
	1 to: currentToken size do: [:i | | c |
		c := currentToken at: i.
		((self isSelectorCharacter: c) or: [i = 1 and: [c = $-]]) 
			ifFalse: [^false]].
	^true