blinkPrevParen: openDelimiter
	| closeDelimiter level string here hereChar |
	string := paragraph text string.
	here := startBlock stringIndex.
	closeDelimiter := '([{' at: (')]}' indexOf: openDelimiter).
	level := 1.
	[level > 0 and: [here > 2]]
		whileTrue:
			[hereChar := string at: (here := here - 1).
			hereChar = closeDelimiter
				ifTrue:
					[level := level - 1.
					level = 0
						ifTrue: [^ self blinkParenAt: here]]
				ifFalse:
					[hereChar = openDelimiter
						ifTrue: [level := level + 1]]].