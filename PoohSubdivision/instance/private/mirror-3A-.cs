mirror: half
	"Mirror one half-mesh and return a full mesh"
	| vtx nrm tex faces faceOffset vtxOffset mesh |
	vtx _ B3DVector3Array new: half vertices size * 2.
	nrm _ B3DVector3Array new: half vertexNormals size * 2.
	tex _ B3DVector2Array new: half texCoords size * 2.
	faces _ B3DIndexedTriangleArray new: (half faces size * 2).
	"Fill in first half"
	vtx 
		privateReplaceFrom: 1 
		to: half vertices basicSize 
		with: half vertices 
		startingAt: 1.
	nrm 
		privateReplaceFrom: 1 
		to: half vertexNormals basicSize 
		with: half vertexNormals 
		startingAt: 1.
	tex 
		privateReplaceFrom: 1 
		to: half texCoords basicSize 
		with: half texCoords 
		startingAt: 1.
	faces 
		privateReplaceFrom: 1 
		to: half faces basicSize 
		with: half faces 
		startingAt: 1.

	"fill in second half"
	half transformBy: (B3DMatrix4x4 withScale: 1@1@-1).
	Preferences twoSidedPoohTextures ifTrue:[
		half texCoords do:[:tx| tx v: (1.0 - tx v)].
	].
	vtx 
		privateReplaceFrom: half vertices basicSize + 1 
		to: vtx basicSize 
		with: half vertices 
		startingAt: 1.
	nrm 
		privateReplaceFrom: half vertexNormals basicSize + 1 
		to: nrm basicSize 
		with: half vertexNormals 
		startingAt: 1.
	tex 
		privateReplaceFrom: half texCoords basicSize + 1 
		to: tex basicSize 
		with: half texCoords 
		startingAt: 1.
	faceOffset _ half faces basicSize.
	vtxOffset _ half vertices size.
	1 to: half faces size do:[:i|
		faces 
			basicAt: (faceOffset _ faceOffset + 1) 
			put: (half faces basicAt: (i-1) * 3 + 3) + vtxOffset.
		faces 
			basicAt: (faceOffset _ faceOffset + 1) 
			put: (half faces basicAt: (i-1) * 3 + 2) + vtxOffset.
		faces 
			basicAt: (faceOffset _ faceOffset + 1) 
			put: (half faces basicAt: (i-1) * 3 + 1) + vtxOffset.
	].
	mesh _ B3DIndexedTriangleMesh new.
	mesh vertices: vtx.
	mesh vertexNormals: nrm.
	mesh faces: faces.
	mesh texCoords: tex.
	^mesh