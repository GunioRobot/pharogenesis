nodesDo: aBlock
	| node |
	node := pointers first.
	[node notNil]
		whileTrue:
			[aBlock value: node.
			node := node next]