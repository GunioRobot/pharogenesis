nodesForParent: aNode
	^ (aNode perform: selector) do: [:ea | ea metaNode: metaNode]
