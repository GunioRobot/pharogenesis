checkSuccessExpr
	"Return the parse tree for an expression that aborts the primitive if the successFlag is not true."

	| expr |
	expr _ 'interpreterProxy failed ifTrue: [^nil]'.
	^ self statementsFor: expr varName: ''
