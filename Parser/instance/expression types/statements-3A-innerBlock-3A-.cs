statements: argNodes innerBlock: inner

	| stmts returns start more blockComment |
	stmts _ OrderedCollection new.
	"give initial comment to block, since others trail statements"
	blockComment _ currentComment.
	currentComment _ nil.
	returns _ false.
	more _ hereType ~~ #rightBracket.
	[more]
		whileTrue: 
		[start _ self startOfNextToken.
		(returns _ self matchReturn)
			ifTrue: 
				[self expression
					ifFalse: [^self expected: 'Expression to return'].
				self addComment.
				stmts addLast: (parseNode isReturningIf
					ifTrue: [parseNode]
					ifFalse: [ReturnNode new
							expr: parseNode
							encoder: encoder
							sourceRange: (start to: self endOfLastToken)])]
			ifFalse: 
				[self expression
					ifTrue: 
						[self addComment.
						stmts addLast: parseNode]
					ifFalse: 
						[self addComment.
						stmts size = 0
							ifTrue: 
								[stmts addLast: 
									(encoder encodeVariable:
										(inner ifTrue: ['nil'] ifFalse: ['self']))]]].
		returns 
			ifTrue: 
				[self match: #period.
				(hereType == #rightBracket or: [hereType == #doIt])
					ifFalse: [^self expected: 'End of block']].
		more _ returns not and: [self match: #period]].
	parseNode _ BlockNode new
				arguments: argNodes
				statements: stmts
				returns: returns
				from: encoder.
	parseNode comment: blockComment.
	^ true