asTranslatorNode
	^TReturnNode new 
		setExpression: expr asTranslatorNode;
		comment: comment