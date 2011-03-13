b3dClipPolygon
	"Primitive. Clip the polygon given in the vertexArray using the temporary vertex array which is assumed to have sufficient size."
	| outMask vtxCount vtxArray tempVtxArray count |
	self export: true.
	self inline: false.
	self var: #vtxArray declareC:'int *vtxArray'.
	self var: #tempVtxArray declareC:'int *tempVtxArray'.
	interpreterProxy methodArgumentCount = 4
		ifFalse:[^interpreterProxy primitiveFail].
	outMask _ interpreterProxy stackIntegerValue: 0.
	vtxCount _ interpreterProxy stackIntegerValue: 2.
	vtxArray _ self stackPrimitiveVertexArray: 3 ofSize: vtxCount + 4.
	tempVtxArray _ self stackPrimitiveVertexArray: 1 ofSize: vtxCount + 4.
	(vtxArray == nil or:[tempVtxArray == nil or:[interpreterProxy failed]])
		ifTrue:[^interpreterProxy primitiveFail].
	"Hack pointers for one-based indexes"
	vtxArray _ vtxArray - PrimVertexSize.
	tempVtxArray _ tempVtxArray - PrimVertexSize.
	count _ self clipPolygon: vtxArray count: vtxCount with: tempVtxArray mask: outMask.
	interpreterProxy pop: 5.
	interpreterProxy pushInteger: count.