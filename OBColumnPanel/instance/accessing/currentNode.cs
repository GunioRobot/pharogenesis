currentNode
	^ self currentColumn ifNotNilDo: [:column | column selectedNode]