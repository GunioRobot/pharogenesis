convertToDoLoop
	"If statements contains the pattern
		var _ startConst.
		[var <= limit] whileTrue: [...statements... var _ var + incConst]
	then replace this by
		startConst to: limit by: incConst do: [:var | ...statements...]"
	| initStmt toDoStmt limitStmt |
	statements size < 2 ifTrue: [^ self].
	initStmt _ statements at: statements size-1.
	(toDoStmt _ statements last toDoFromWhileWithInit: initStmt)
		== nil ifTrue: [^ self].
	statements removeLast; removeLast; addLast: toDoStmt.
	initStmt variable scope: -1.  "Flag arg as block temp"
	statements size < 2 ifTrue: [^ self].
	limitStmt _ statements at: statements size-1.
	(toDoStmt _ statements last toDoWithLimit: limitStmt)
		== nil ifTrue: [^ self].
	statements removeLast; removeLast; addLast: toDoStmt.
	limitStmt variable scope: -2.  "Flag limit var as block temp"
