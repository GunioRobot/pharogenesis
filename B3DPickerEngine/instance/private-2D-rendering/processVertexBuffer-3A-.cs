processVertexBuffer: vb
	| minIndex minVertex minW |
	minIndex _ self primComputeMinIndexZ: vb primitive vtxArray: vb vertexArray vtxSize: vb vertexCount idxArray: vb indexArray idxSize: vb indexCount.
	minIndex == nil ifTrue:[minIndex _ super processVertexBuffer: vb].
	minIndex = 0 ifTrue:[^maxVtx].
	minVertex _ vb vertexArray at: minIndex.
	minW _ minVertex rasterPosW.
	minW = 0.0 ifFalse:[minVertex rasterPosZ: minVertex rasterPosZ / minW].
	^minVertex