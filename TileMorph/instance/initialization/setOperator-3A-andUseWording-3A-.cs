setOperator: aString andUseWording: wording
	"Set the operator symbol from the string provided"

	type _ #operator.
	operatorOrExpression _ aString asSymbol.
 	self line1: wording.
	(ScriptingSystem doesOperatorWantArrows: operatorOrExpression)
		ifTrue: [self addArrows].
	self updateLiteralLabel

	"operatorOrExpression == #heading ifTrue: [self halt]."