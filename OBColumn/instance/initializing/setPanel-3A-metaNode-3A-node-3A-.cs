setPanel: aPanel metaNode: aMetaNode node: aNode 
	panel := aPanel.
	self subscribe.
	filter := aMetaNode filter monitor: self.
	children _ self filter nodesForParent: aNode.
	self clearSelection