processPolygon: vb
	"Process a polygon defined by the vertex buffer"
	| objSize |
	objSize _ self primObjectSize + (vb vertexCount * PrimVertexSize) + (vb vertexCount - 2 * 3).
	self addPrimitiveObject: vb ofSize: objSize.