setOperatorAndUseArrows: aString
	"Set the operator as per aString, and add up/down arrows"

	type _ #operator.
	operatorOrExpression _ aString asSymbol.
 	self line1: (self currentVocabulary tileWordingForSelector: operatorOrExpression).
	self addArrows; updateLiteralLabel.
	submorphs last setBalloonText: (ScriptingSystem helpStringForOperator: operatorOrExpression)