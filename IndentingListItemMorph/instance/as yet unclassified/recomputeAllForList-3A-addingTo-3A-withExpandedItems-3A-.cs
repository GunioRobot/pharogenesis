recomputeAllForList: hostList addingTo: aCollection withExpandedItems: expandedItems

	self halt.	"not used"

	"self withSiblingsDo: [ :aNode |
		aNode 
			recomputeForList: hostList 
			addingTo: aCollection 
			withExpandedItems: expandedItems.
	].
"