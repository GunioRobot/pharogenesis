setOperator: aString

	type _ #operator.
	operatorOrExpression _ aString asSymbol.
 	self line1: (ScriptingSystem wordingForOperator: aString).
	(ScriptingSystem doesOperatorWantArrows: operatorOrExpression)
		ifTrue: [self addArrows; updateLiteralLabel].

	"operatorOrExpression == #heading ifTrue: [self halt]."