recomputeForList: hostList addingTo: aCollection withExpandedItems: expandedItems

	self contents: complexContents asString.
	aCollection add: self.
	isExpanded ifTrue: [
		self 
			addChildrenForList: hostList 
			addingTo: aCollection 
			withExpandedItems: expandedItems].
