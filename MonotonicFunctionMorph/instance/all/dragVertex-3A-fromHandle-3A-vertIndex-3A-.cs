dragVertex: evt fromHandle: handle vertIndex: ix
	| p r |
	"Constrain to owner bounds"
	r _ owner innerBounds.

	"Constrain between adjacent points"
	ix > 1 ifTrue: [r _ r withLeft: (vertices at: ix-1) x].
	ix < vertices size ifTrue: [r _ r withRight: (vertices at: ix+1) x].

	owner isWorldOrHandMorph ifFalse:
		["Constrain first and last points to sides"
		ix = 1 ifTrue: [r _ r withRight: r left].
		ix = vertices size ifTrue: [r _ r withLeft: r right]].

	p _ evt cursorPoint adhereTo: r.
	vertices at: ix put: p.
	handle position: p - (handle extent//2).
	self computeBounds