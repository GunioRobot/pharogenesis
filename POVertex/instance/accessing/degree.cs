degree
	| edge count start |
	start _ self halfedge.
	start ifNil: [^ 0].
	edge _ start opposite.
	count _ 1.
	[edge next = start]
		whileFalse: 
			[edge _ edge next opposite.
			count _ count + 1].
	^ count