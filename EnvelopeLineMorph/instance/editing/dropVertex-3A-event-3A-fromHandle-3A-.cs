dropVertex: ix event: evt fromHandle: handle
	| oldVerts |
	oldVerts _ vertices.
	super dropVertex: ix event: evt fromHandle: handle.
	vertices = oldVerts ifFalse: [owner deletePoint: ix "deleted a vertex"]