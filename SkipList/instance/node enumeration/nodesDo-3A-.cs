nodesDo: aBlock
	| node |
	node _ pointers first.
	[node notNil]
		whileTrue:
			[aBlock value: node.
			node _ node next]