toDoWithLimit: limitStmt
	"The receiver is a to:do: statement, preceded by a statement
	that might be of the form {iLimiT _ expr}.  If so, replace the
	limit argument by the given expr and return a new to:do: node.
	Otherwise, return nil"
	((limitStmt isMemberOf: AssignmentNode)
		and: [limitStmt variable = arguments first])
		ifFalse: [^ nil].
	limitStmt variable key = (arguments last firstArgument key , 'LimiT')
		ifFalse: [^ nil].  "Must be a generated temp"
	arguments at: 1 put: (limitStmt value)