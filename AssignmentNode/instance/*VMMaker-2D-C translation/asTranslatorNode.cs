asTranslatorNode
"make a CCodeGenerator equivalent of me"
	^TAssignmentNode new
		setVariable: variable asTranslatorNode
		expression: value asTranslatorNode;
		comment: comment