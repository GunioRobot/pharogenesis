splitVerticesFrom: aDictionary
	"Split the non smooth vertices from the Dictionary
		vertex index -> Dictionary
							smoothing group -> list of face indexes.
	"
	| newVertices newColors newTexCoords nextIndex vtxIndex nValues skipAssoc faceList iFace |
	newVertices _ WriteStream with: vertices.
	vtxColors ifNotNil:[newColors _ WriteStream with: vtxColors].
	vtxTexCoords ifNotNil:[newTexCoords _ WriteStream with: vtxTexCoords].
	nextIndex _ vertices size.
	aDictionary associationsDo:[:vertexAssoc|
		vtxIndex _ vertexAssoc key.
		nValues _ vertexAssoc value size - 1.
		"We have to copy n values"
		newVertices next: nValues put: (vertices at: vtxIndex).
		newColors ifNotNil:[newColors next: nValues put: (vtxColors at: vtxIndex)].
		newTexCoords ifNotNil:[newTexCoords next: nValues put: (vtxTexCoords at: vtxIndex)].
		skipAssoc _ true. "Skip the first association - we can reuse the original vertex"
		vertexAssoc value associationsDo:[:smoothAssoc|
			skipAssoc ifFalse:[
				faceList _ smoothAssoc value.
				nextIndex _ nextIndex + 1.
				faceList do:[:faceIndex|
					iFace _ faces at: faceIndex.
					1 to: 3 do:[:i| (iFace at: i) = vtxIndex ifTrue:[iFace at: i put: nextIndex]].
					faces at: faceIndex put: iFace.
				].
			].
			skipAssoc _ false.
		].
	].
	"Cleanup"
	vtxNormals _ nil. "Must be recomputed"
	vertices _ newVertices contents.
	newColors ifNotNil:[vtxColors _ newColors contents].
	newTexCoords ifNotNil:[vtxTexCoords _ newTexCoords contents].