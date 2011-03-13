getChildren
	children _ self filter nodesForParent: self parent.
	^ children