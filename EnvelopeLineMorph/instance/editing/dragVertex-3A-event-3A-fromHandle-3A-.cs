dragVertex: ix event: evt fromHandle: handle
	| p |
	super dragVertex: ix event: evt fromHandle: handle.
	p _ owner acceptGraphPoint: evt cursorPoint at: ix.
	self verticesAt: ix put: p.
