nextQuotePosIn: sourceString startingFrom: commentStart
	| pos nextQuotePos |
	pos _ commentStart + 1.
	[((nextQuotePos _ sourceString findString: '"' startingAt: pos) == (sourceString findString: '""' startingAt: pos)) and: [nextQuotePos ~= 0]]
		whileTrue:
			[pos _ nextQuotePos + 2].
	^nextQuotePos