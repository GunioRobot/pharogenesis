makePlaneNamed: aString
	"Create a simple plane"
	| tex vertices faces mesh |
	tex _ B3DTexture2Array new: 4.
	tex at: 1 put: (0@0); at: 2 put: (1@0); at: 3 put: (1@1); at: 4 put: (0@1).
	vertices _ B3DVector3Array new: 4.
	vertices  at: 1 put: -1@1@-1; at: 2 put: 1@1@-1; at: 3 put: 1@-1@-1; at: 4 put: -1@-1@-1.
	vertices do:[:vtx| vtx *= 0.5].
	faces _ B3DIndexedTriangleArray new: 2.
	faces at: 1 put: (B3DIndexedTriangle with: 1 with: 2 with: 3).
	faces at: 2 put: (B3DIndexedTriangle with: 3 with: 4 with: 1).
	mesh _ B3DIndexedTriangleMesh new.
	mesh vertices: vertices.
	mesh faces: faces.
	mesh texCoords: tex.
	^ self createSimpleActor: mesh named: aString parent: nil