dragVertex: evt fromHandle: handle vertIndex: ix
	| p |
	super dragVertex: evt fromHandle: handle vertIndex: ix.
	p _ owner acceptGraphPoint: evt cursorPoint at: ix.
	vertices at: ix put: p.
	self computeBounds