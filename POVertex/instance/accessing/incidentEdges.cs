incidentEdges
	| edge start edges |
	edges _ OrderedCollection new.
	start _ self halfedge.
	start ifNil: [^ nil].
	edge _ start.
	edges add: edge.
	[edge opposite next = start]
		whileFalse: 
			[edge _ edge opposite next.
			edges add: edge].
	^ edges