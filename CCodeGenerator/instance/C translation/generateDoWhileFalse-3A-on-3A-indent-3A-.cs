generateDoWhileFalse: msgNode on: aStream indent: level
	"Generate do {stmtList} while(!(cond))"

	| stmts testStmt |
	stmts _ msgNode receiver statements asOrderedCollection.
	testStmt _ stmts removeLast.
	msgNode receiver setStatements: stmts.
	aStream nextPutAll: 'do {'; cr.
	msgNode receiver emitCCodeOn: aStream level: level + 1 generator: self.
	level timesRepeat: [ aStream tab ].
	aStream nextPutAll: '} while(!('.
	testStmt emitCCodeOn: aStream level: 0 generator: self.
	aStream nextPutAll: '))'.