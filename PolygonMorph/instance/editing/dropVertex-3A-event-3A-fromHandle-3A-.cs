dropVertex: ix event: evt fromHandle: handle
	| p |
	p _ vertices at: ix.
	(((vertices atWrap: ix-1) dist: p) < 3 or:
		[((vertices atWrap: ix+1) dist: p) < 3])
		ifTrue: ["Drag a vertex onto its neighbor means delete"
				self setVertices: (vertices copyReplaceFrom: ix to: ix with: Array new)].
	evt shiftPressed
		ifTrue: [self removeHandles]
		ifFalse: [self addHandles "remove then add to recreate"]