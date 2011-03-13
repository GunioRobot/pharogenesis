columnInPanel: aBrowser node: aNode
	columnClass ifNil: [columnClass _ OBColumn].
	^ columnClass
		inPanel: aBrowser
		metaNode: self
		node: aNode