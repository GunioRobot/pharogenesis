transformBy: aMatrix
	"Modify the mesh by transforming it using a matrix; this allows us to change the insertion point of the mesh"

	vertices do: [:vtx | 	vtx privateLoadFrom: ((aMatrix composeWith:
										(B3DMatrix4x4 identity translation: vtx)) translation) ].

	bBox ifNotNil: [ self computeBoundingBox ].
	self computeVertexNormals.
