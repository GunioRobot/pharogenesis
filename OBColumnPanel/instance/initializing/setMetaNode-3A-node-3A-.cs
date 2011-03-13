setMetaNode: aMetaNode node: aNode 
	root _ aNode.
	root metaNode: aMetaNode.
	self pushColumn: (aMetaNode columnInPanel: self node: root).
	minPanes - self columns size 
		timesRepeat: [self pushColumn: self emptyColumn]