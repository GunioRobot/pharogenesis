pinMoved
	| newVerts |
	newVerts _ vertices copy.
	newVerts at: 1 put: pins first wiringEndPoint.
	newVerts at: newVerts size put: pins last wiringEndPoint.
	self setVertices: newVerts