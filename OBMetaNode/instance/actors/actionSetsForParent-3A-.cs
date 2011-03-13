actionSetsForParent: aNode
	^ actors collect: [:actor | actor actionsForParent: aNode]