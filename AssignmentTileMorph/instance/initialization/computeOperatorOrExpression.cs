computeOperatorOrExpression
	| aSuffix |
	operatorOrExpression _ (assignmentRoot, assignmentSuffix) asSymbol.
	aSuffix _ ScriptingSystem wordingForAssignmentSuffix: assignmentSuffix.
	operatorReadoutString _ assignmentRoot, ' ', aSuffix.
 	self line1: operatorReadoutString.
	self addArrowsIfAppropriate