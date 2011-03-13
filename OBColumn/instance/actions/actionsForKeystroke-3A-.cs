actionsForKeystroke: aChar
	^self actionsForParentNode, self actionsForSelectedNode
		select: [:anAction | anAction keystroke == aChar]