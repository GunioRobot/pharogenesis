addActionsToMenu: aMenu
	self actionSetsForParentNode, self actionSetsForSelectedNode
		do: 
			[:set 
			|set do: 
				[:action | 
				action announcer: self announcer.
				action addItemToMenu: aMenu]]
		separatedBy: [aMenu addLine]