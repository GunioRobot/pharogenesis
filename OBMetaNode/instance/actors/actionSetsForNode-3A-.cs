actionSetsForNode: aNode
	^ actors collect: [:actor | actor actionsForNode: aNode]