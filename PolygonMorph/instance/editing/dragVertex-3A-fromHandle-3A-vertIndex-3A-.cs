dragVertex: evt fromHandle: handle vertIndex: ix
	| p |
	p _ evt cursorPoint.
	vertices at: ix put: p.
	handle position: p - (handle extent//2).
	self computeBounds