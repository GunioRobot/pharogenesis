drawPolygonMesh: aB3DPolygonMesh
	"Draw a generic polygon mesh"
	| hasVtxNormals hasTexCoords hasVtxColors bounds box |
	box _ nil.
	aB3DPolygonMesh polygonsDo:[:poly|
		hasVtxNormals _ poly hasVertexNormals.
		hasTexCoords _ poly hasTextureCoords.
		hasVtxColors _ poly hasVertexColors.
		"Set the normal of the polygon if we don't have normals per vertex"
		hasVtxNormals 
			ifFalse:[self normal: poly normal].
		bounds _ self drawPolygonAfter:[
			poly verticesDo:[:vtx|
				hasVtxColors ifTrue:[self color: (poly colorOfVertex: vtx)].
				hasVtxNormals ifTrue:[self normal: (poly normalOfVertex: vtx)].
				hasTexCoords ifTrue:[self texCoord: (poly texCoordOfVertex: vtx)].
				self vertex: vtx.
			].
		].
		box == nil ifTrue:[box _ bounds] ifFalse:[box _ box quickMerge: bounds].
	].
	^box