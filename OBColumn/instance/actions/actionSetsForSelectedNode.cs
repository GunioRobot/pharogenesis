actionSetsForSelectedNode
	| node |
	node _ self selectedNode ifNil: [^ #()].
	^ node metaNode actionSetsForNode: node	