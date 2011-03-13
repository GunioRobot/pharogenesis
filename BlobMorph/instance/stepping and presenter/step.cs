step
	| verts |
	self comeToFront.
	self mergeBlobs.
	verts := vertices copy.

	" change two points at random to cause oozing across screen "
	self oozeAFewPointsOf: verts.

	" limit radius and interpoint angle "
	verts := self limitRange: verts.

	" Set new vertices; bounce off a wall if necessary "
	self setVertices: verts.
	self bounceOffWalls.
	self adjustColors
