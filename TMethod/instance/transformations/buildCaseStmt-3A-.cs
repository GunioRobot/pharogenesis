buildCaseStmt: aSendNode
	"Build a case statement node for the given send of dispatchOn:in:."
	"Note: the first argument is the variable to be dispatched on. The second argument is a constant node holding an array of unary selectors, which will be turned into sends to self."

	((aSendNode args size = 2) and:
	 [aSendNode args last isConstant and:
	 [aSendNode args last value class = Array]]) ifFalse: [
		self error: 'wrong node structure for a case statement'.
	].

	^TCaseStmtNode new
		setExpression: aSendNode args first
		selectors: aSendNode args last value