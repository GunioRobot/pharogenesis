selectAncestorOf: aNode withParent: parentNode
	^ (metaNode nodesForParent: parentNode)
		detect: [:child | child isAncestorOf: aNode] 
		ifNone: [nil]