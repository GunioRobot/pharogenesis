processIndexedQuads: vb
	| vtxArray out idx1 idxArray idx2 idx3 face obj idx4 |
	vtxArray _ self loadVerticesFrom: vb.
	idxArray _ vb indexArray.
	out _ WriteStream on: (B3DIndexedTriangleArray new: vb indexCount // 3 * 2).
	1 to: vb indexCount by: 4 do:[:i|
		idx1 _ idxArray at: i.
		idx2 _ idxArray at: i+1.
		idx3 _ idxArray at: i+2.
		idx4 _ idxArray at: i+3.
		idx1 = 0 ifFalse:[
			face _ B3DIndexedTriangle with: idx1 with: idx2 with: idx3.
			out nextPut: face.
			face _ B3DIndexedTriangle with: idx3 with: idx4 with: idx1.
			out nextPut: face].
	].
	obj _ B3DPrimitiveObject new.
	obj faces: out contents.
	obj vertices: vtxArray.
	obj texture: texture.
	obj mapVertices: viewport.
	obj setupVertexOrder.
	obj sortInitialFaces.
	scanner addObject: obj.