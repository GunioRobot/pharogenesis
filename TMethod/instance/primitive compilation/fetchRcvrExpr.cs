fetchRcvrExpr
	"Return the parse tree for an expression that fetches the receiver from the stack."

	| expr |
	expr _ 'rcvr _ self stackValue: (', args size printString, ')'.
	^ self statementsFor: expr varName: ''
