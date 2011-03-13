parent: aNode
	
	self filter: aNode metaNode filter.
	self getChildren.
	self clearSelection.
	self changed: #list.
	panel clearAfter: self