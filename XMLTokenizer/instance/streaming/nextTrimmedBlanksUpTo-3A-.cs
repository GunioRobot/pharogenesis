nextTrimmedBlanksUpTo: delimiter
	| resultStream nextChar |
	resultStream _ WriteStream on: (String new: 10).
	nextChar _ nil.
	[peekChar _ self peek.
	peekChar
		ifNotNil: [
			[peekChar == $ 
				and: [nextChar == $ ]]
				whileTrue: [peekChar _ self next]].
	(nextChar _ self next) == delimiter]
		whileFalse: [resultStream nextPut: nextChar].
	nextChar == delimiter
		ifFalse: [self parseError: 'XML no delimiting ' , delimiter printString , ' found'].
	^resultStream contents
