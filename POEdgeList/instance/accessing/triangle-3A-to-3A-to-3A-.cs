triangle: first to: second to: third 
	| e1 e2 e3 triangle oldtriangle area p1 p2 p3 |
	p1 _ first.
	p2 _ second.
	p3 _ third.
	area _ p2 y + p1 y * (p2 x - p1 x) + (p3 y + p2 y * (p3 x - p2 x)) + (p1 y + p3 y * (p1 x - p3 x)).
	area positive
		ifTrue: 
			[p1 _ second.
			p2 _ first].
	e1 _ self edgeFrom: p1 to: p2.
	e2 _ self edgeFrom: p2 to: p3.
	e3 _ self edgeFrom: p3 to: p1.
	triangle _ POTriangle
				with: e1
				with: e2
				with: e3.
	oldtriangle _ self faces at: triangle ifAbsent: [self faces at: triangle put: triangle].
	triangle vertices do: [:vertex | vertex faces add: triangle].
	^ oldtriangle