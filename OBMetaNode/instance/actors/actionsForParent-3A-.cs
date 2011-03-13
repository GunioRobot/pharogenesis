actionsForParent: aNode
	^ (self actionSetsForParent: aNode) gather: [:ea | ea]