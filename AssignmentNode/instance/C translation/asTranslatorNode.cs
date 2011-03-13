asTranslatorNode
	^TAssignmentNode new
		setVariable: variable asTranslatorNode
		expression: value asTranslatorNode;
		comment: comment