from3DS: aDictionary
	| triList triSpec triSize tri flags |
	aDictionary isEmpty ifTrue:[^nil].
	vertices _ aDictionary at: #vertexList.
	"matrix _ aDictionary at: #matrix ifAbsent:[nil].
	matrix ifNotNil:[matrix quickTransformV3ArrayFrom: vertices to: vertices]."
	vtxTexCoords _ aDictionary at: #textureVertices ifAbsent:[nil].
	triList _ aDictionary at: #triList.
	triSpec _ triList first.
	triSize _ triSpec size.
	faces _ B3DIndexedTriangleArray new: triSize.
	edgeFlags _ ByteArray new: triSize.
	1 to: triSize do:[:i|
		tri _ (triSpec at: i) key.
		flags _ (triSpec at: i) value.
		faces at: i put: (B3DIndexedTriangle with: tri first with: tri second with: tri third).
		edgeFlags at: i put: flags].
	triList second ifNotNil:[
		smoothFlags _ WordArray new: triSize.
		triList second doWithIndex:[:smoothFlag :index| smoothFlags at: index put: smoothFlag]].
