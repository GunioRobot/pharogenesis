recomputeForList: hostList addingTo: aCollection withExpandedItems: expandedItems

	self halt.	"no longer used"

	
	"self contents: complexContents asString.
	aCollection add: self."
	"isExpanded ifTrue: [
		self 
			addChildrenForList: hostList 
			addingTo: aCollection 
			withExpandedItems: expandedItems]."
