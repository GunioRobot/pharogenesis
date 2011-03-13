asTranslatorNode
	^TStmtListNode new
		setArguments: #()
		statements: (messages collect:
			[ :msg | msg asTranslatorNode receiver: receiver asTranslatorNode ]);
		comment: comment