currentOrRootNode
	^(self columns reversed detect: [:ea | ea hasSelection]
		ifNone: [^self columns first parent]) selectedNode