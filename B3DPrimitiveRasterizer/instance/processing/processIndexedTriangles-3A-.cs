processIndexedTriangles: vb
	| objSize |
	objSize _ self primObjectSize + (vb vertexCount + 1 * PrimVertexSize) + (vb indexCount).
	self addPrimitiveObject: vb ofSize: objSize.