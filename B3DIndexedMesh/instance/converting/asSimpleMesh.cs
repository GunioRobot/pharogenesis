asSimpleMesh
	"Convert the receiver into a very simple mesh representation"
	| simpleFaces oldFace newVtx newFace newVertices pos |
	simpleFaces _ WriteStream on: (Array new: faces size).
	newVertices _ WriteStream on: (Array new: 10).
	1 to: faces size do:[:i|
		oldFace _ faces at: i.
		newVertices reset.
		1 to: oldFace size do:[:j|
			pos _ oldFace at: j.
			newVtx _ B3DSimpleMeshVertex new.
			newVtx position: (vertices at: pos).
			vtxNormals == nil ifFalse:[newVtx normal: (vtxNormals at: pos)].
			vtxColors == nil ifFalse:[newVtx color: (vtxColors at: pos)].
			vtxTexCoords == nil ifFalse:[newVtx texCoord: (vtxTexCoords at: pos)].
			newVertices nextPut: newVtx].
		newFace _ B3DSimpleMeshFace withAll: newVertices contents.
		simpleFaces nextPut: newFace].
	^B3DSimpleMesh withAll: simpleFaces contents