xLetter
	"Form a word or keyword."

	| type |
	buffer reset.
	[(type _ typeTable at: hereChar asciiValue) == #xLetter or: [type == #xDigit]]
		whileTrue:
			["open code step for speed"
			buffer nextPut: hereChar.
			hereChar _ aheadChar.
			source atEnd
				ifTrue: [aheadChar _ 30 asCharacter "doit"]
				ifFalse: [aheadChar _ source next]].
	type == #colon
		ifTrue: 
			[buffer nextPut: self step.
			tokenType _ #keyword]
		ifFalse: 
			[tokenType _ #word].
	token _ buffer contents