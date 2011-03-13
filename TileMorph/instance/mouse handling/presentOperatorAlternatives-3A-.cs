presentOperatorAlternatives: evt
	"The receiver is a tile that represents an operator; a click on the receiver's label will pop up a menu of alternative operator choices"

	| result ops |

	((ops := ScriptingSystem arithmeticalOperatorsAndHelpStrings first) includes: operatorOrExpression) ifFalse:
		[((ops := ScriptingSystem numericComparitorsAndHelpStrings first) includes: operatorOrExpression)
			ifFalse: [^ self]].
		
	(result := (SelectionMenu selections: ops) startUp) ifNotNil:
		[self setOperatorAndUseArrows: result asString.
		self scriptEdited]