parseStatementListForBraceArray
	"same as parseStatementList, but does not allow empty statements e.g {...$a...}.
	A single terminating . IS allowed e.g. {$a.} "

	
	[currentTokenFirst ~= $} ifTrue: [self parseStatement].
	currentTokenFirst = $.] 
		whileTrue: [self scanPast: #statementSeparator]