blinkPrevParen
	| openDelimiter closeDelimiter level string here hereChar |
	string _ paragraph text string.
	here _ startBlock stringIndex.
	openDelimiter _ sensor keyboardPeek.
	closeDelimiter _ '([{' at: (')]}' indexOf: openDelimiter).
	level _ 1.
	[level > 0 and: [here > 2]]
		whileTrue:
			[hereChar _ string at: (here _ here - 1).
			hereChar = closeDelimiter
				ifTrue:
					[level _ level - 1.
					level = 0
						ifTrue: [^ self blinkParenAt: here]]
				ifFalse:
					[hereChar = openDelimiter
						ifTrue: [level _ level + 1]]].