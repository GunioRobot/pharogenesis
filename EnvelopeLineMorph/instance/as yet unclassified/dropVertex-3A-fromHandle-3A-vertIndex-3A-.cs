dropVertex: evt fromHandle: handle vertIndex: ix
	| oldVerts |
	oldVerts _ vertices.
	super dropVertex: evt fromHandle: handle vertIndex: ix.
	vertices = oldVerts ifFalse: [owner deletePoint: ix "deleted a vertex"]