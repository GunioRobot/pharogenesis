actionsForParent: aNode
	^ nodeClass 
		ifNotNil: [nodeClass actionsForParent: aNode]
		ifNil: [#()]