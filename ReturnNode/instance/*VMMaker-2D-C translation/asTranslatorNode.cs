asTranslatorNode
"make a CCodeGenerator equivalent of me"
	^TReturnNode new 
		setExpression: expr asTranslatorNode;
		comment: comment