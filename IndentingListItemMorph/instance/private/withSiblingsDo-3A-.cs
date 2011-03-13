withSiblingsDo: aBlock

	| node |
	node _ self.
	[node isNil] whileFalse: [
		aBlock value: node.
		node _ node nextSibling
	].