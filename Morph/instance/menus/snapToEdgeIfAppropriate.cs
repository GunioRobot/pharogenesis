snapToEdgeIfAppropriate
	| edgeSymbol oldBounds aWorld |
	(edgeSymbol _ self valueOfProperty: #edgeToAdhereTo) ifNotNil:
		[oldBounds _ bounds.
		self adhereToEdge: edgeSymbol.
		bounds ~= oldBounds ifTrue: [(aWorld _ self world) ifNotNil: [aWorld viewBox ifNotNil:
			[aWorld displayWorld]]]]