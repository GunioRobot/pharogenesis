setAssignmentSuffix: aString
	assignmentSuffix _ aString.
	self computeOperatorOrExpression.
	type _ #operator.
 	self addArrowsIfAppropriate; updateLiteralLabel.
