recomputeAllForList: hostList addingTo: aCollection withExpandedItems: expandedItems

	self withSiblingsDo: [ :aNode |
		aNode 
			recomputeForList: hostList 
			addingTo: aCollection 
			withExpandedItems: expandedItems.
	].
