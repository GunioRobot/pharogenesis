actionsForSelectedNode
	| node |
	node _ self selectedNode ifNil: [^ #()].
	^ node metaNode actionsForNode: node	