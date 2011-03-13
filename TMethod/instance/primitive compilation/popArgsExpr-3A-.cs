popArgsExpr: argCount
	"Return the parse tree for an expression that pops the given number of arguments from the stack."

	| expr |
	expr _ 'self pop: ', argCount printString.
	^ self statementsFor: expr varName: ''
