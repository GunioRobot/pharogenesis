convertToDoLoop
	"If statements contains the pattern
		var _ startExpr.
		[var <= limit] whileTrue: [...statements... var _ var + incConst]
	then replace this by
		startExpr to: limit by: incConst do: [:var | ...statements...]"
	| initStmt toDoStmt limitStmt |
	statements size < 2 ifTrue: [^ self].
	initStmt _ statements at: statements size-1.
	(toDoStmt _ statements last toDoFromWhileWithInit: initStmt)
		== nil ifTrue: [^ self].
	initStmt variable scope: -1.  "Flag arg as block temp"
	statements removeLast; removeLast; addLast: toDoStmt.

	"Attempt further conversion of the pattern
		limitVar _ limitExpr.
		startExpr to: limitVar by: incConst do: [:var | ...statements...]
	to
		startExpr to: limitExpr by: incConst do: [:var | ...statements...]"
	statements size < 2 ifTrue: [^ self].
	limitStmt _ statements at: statements size-1.
	((limitStmt isMemberOf: AssignmentNode)
		and: [limitStmt variable isTemp
		and: [limitStmt variable == toDoStmt arguments first
		and: [self methodRefersOnlyOnceToTemp: limitStmt variable fieldOffset]]])
		ifFalse: [^ self].
	toDoStmt arguments at: 1 put: limitStmt value.
	limitStmt variable scope: -2.  "Flag limit var so it won't print"
	statements removeLast; removeLast; addLast: toDoStmt.

