plainTextureRect
	"Create a new plain rectangle w/ texture coords"

	vertices _ B3DVector3Array new: 4.
	vertices at: 1 put: (-1@-1@0).
	vertices at: 2 put: (1@-1@0).
	vertices at: 3 put: (1@1@0).
	vertices at: 4 put: (-1@1@0).

	vtxTexCoords _ B3DTexture2Array new: 4.
	vtxTexCoords at: 1 put: (0@1).
	vtxTexCoords at: 2 put: (1@1).
	vtxTexCoords at: 3 put: (1@0).
	vtxTexCoords at: 4 put: (0@0).

	faces _ B3DIndexedQuadArray new: 1.
	faces at: 1 put: (B3DIndexedQuad with: 1 with: 2 with: 3 with: 4).