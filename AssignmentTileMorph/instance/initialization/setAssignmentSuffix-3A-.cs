setAssignmentSuffix: aString
	assignmentSuffix _ aString.
	self computeOperatorOrExpression.
	type _ #operator.
 	self line1: (ScriptingSystem wordingForOperator: operatorOrExpression).
	self addArrowsIfAppropriate; updateLiteralLabel