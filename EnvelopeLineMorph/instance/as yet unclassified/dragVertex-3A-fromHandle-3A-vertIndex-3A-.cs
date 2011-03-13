dragVertex: evt fromHandle: handle vertIndex: ix
	| p |
	super dragVertex: evt fromHandle: handle vertIndex: ix.
	p _ owner acceptGraphPoint: evt cursorPoint at: ix.
	self verticesAt: ix put: p.
