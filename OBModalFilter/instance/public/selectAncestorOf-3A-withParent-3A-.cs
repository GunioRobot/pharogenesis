selectAncestorOf: aNode withParent: parentNode
	| ancestor |
	1 	to: metaNode edges size 
	  	do: [:i | selection _ i.
			ancestor _ (self nodesForParent: parentNode)
				detect: [:child | child isAncestorOf: aNode] 
				ifNone: [nil].
			ancestor ifNotNil: [self changed: #selection. ^ ancestor]].
	^ nil