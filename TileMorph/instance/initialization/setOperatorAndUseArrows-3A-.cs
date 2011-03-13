setOperatorAndUseArrows: aString

	type _ #operator.
	operatorOrExpression _ aString asSymbol.
 	self line1: (ScriptingSystem wordingForOperator: aString).
	self addArrows; updateLiteralLabel