processPolygon: vb
	| vtxArray out face obj |
	vtxArray _ self loadVerticesFrom: vb.
	out _ WriteStream on: (B3DIndexedTriangleArray new: vtxArray size - 2).
	3 to: vb vertexCount do:[:i|
		face _ B3DIndexedTriangle with: 1 with: i-1 with: i.
		out nextPut: face.
	].
	obj _ B3DPrimitiveObject new.
	obj faces: out contents.
	obj vertices: vtxArray.
	obj texture: texture.
	obj mapVertices: viewport.
	obj setupVertexOrder.
	obj sortInitialFaces.
	scanner addObject: obj.