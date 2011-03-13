actionsForNode: aNode
	^ (self actionSetsForNode: aNode) gather: [:ea | ea]