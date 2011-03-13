convertToDoLoop
	"If statements contains the pattern
		var _ startConst.
		[var <= limit] whileTrue: [...statements... var _ var + incConst]
	then replace this by
		startConst to: limit by: incConst do: [:var | ...statements...]"
	| initStmt toDoStmt |
	statements size < 2 ifTrue: [^ self].
	initStmt _ statements at: statements size-1.
	(initStmt isMemberOf: AssignmentNode) ifTrue:
		[toDoStmt _ statements last whileAsToDo: initStmt.
		toDoStmt notNil ifTrue:
			[statements removeLast; removeLast; addLast: toDoStmt]]