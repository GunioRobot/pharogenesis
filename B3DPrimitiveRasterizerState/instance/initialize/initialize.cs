initialize
	faceAlloc ifNil:[faceAlloc _ B3DPrimitiveRasterizerData new: 32768].
	edgeAlloc ifNil:[edgeAlloc _ B3DPrimitiveRasterizerData new: 16384].
	attrAlloc ifNil:[attrAlloc _ B3DPrimitiveRasterizerData new: 4096].
	aet ifNil:[aet _ B3DPrimitiveRasterizerData new: 4096].
	addedEdges ifNil:[addedEdges _ B3DPrimitiveRasterizerData new: 4096].
	fillList ifNil:[fillList _ B3DPrimitiveRasterizerData new: 32].
	self primInitializeBuffers.