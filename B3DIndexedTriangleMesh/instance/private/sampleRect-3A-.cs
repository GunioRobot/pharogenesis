sampleRect: n
	"B3DIndexedQuadMesh new sampleRect"
	| vtx face |
	vtx _ WriteStream on: (B3DVector3Array new).
	n negated to: n do:[:x|
		n negated to: n do:[:y|
			vtx nextPut: (B3DVector3 x: x y: y z: 0) /= n asFloat.
		].
	].
	vertices _ vtx contents.
	vtxNormals _ B3DVector3Array new: (2*n+1) squared.
	1 to: vtxNormals size do:[:i| vtxNormals at: i put: (0@0@-1)].
	faces _ B3DIndexedTriangleArray new: (2*n) squared.
	0 to: 2*n-1 do:[:i|
		1 to: 2*n do:[:j|
			face _ B3DIndexedTriangle 
						with: (i*(2*n+1)+j)
						with: (i*(2*n+1)+j+1)
						with: (i+1*(2*n+1)+j+1)
						"with: (i+1*(2*n+1)+j)".
			faces at: i*2*n+j put: face.
			"face _ B3DIndexedTriangle 
						with: (i*(2*n+1)+j)
						with: (i*(2*n+1)+j+1)
						with: (i+1*(2*n+1)+j+1)
						with: (i+1*(2*n+1)+j).
			"
		]].