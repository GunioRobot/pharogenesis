primitiveProcessVertexBuffer
	| idxCount vtxCount vtxArray idxArray texHandle primType result box array |
	self export: true.
	self var: #idxArray type: 'int *'.
	self var: #vtxArray type: 'float *'.
	self var: #box declareC:'int box[4] = { 0, 0, 0, 0 }'.
	interpreterProxy methodArgumentCount = 6
		ifFalse:[^interpreterProxy primitiveFail].
	idxCount _ interpreterProxy stackIntegerValue: 0.
	vtxCount _ interpreterProxy stackIntegerValue: 2.
	texHandle _ interpreterProxy stackIntegerValue: 4.
	primType _ interpreterProxy stackIntegerValue: 5.
	interpreterProxy failed ifTrue:[^nil].
	vtxArray _ self stackPrimitiveVertexArray: 3 ofSize: vtxCount.
	idxArray _ self stackPrimitiveIndexArray: 1 ofSize: idxCount validate: true forVertexSize: vtxCount.
	(vtxArray == nil or:[idxArray == nil 
		or:[primType < 1 or:[primType > PrimTypeMax 
			or:[interpreterProxy failed]]]])
				ifTrue:[^interpreterProxy primitiveFail].

	result _ self cCode:'b3dxRasterizeVertexBuffer(primType, texHandle, vtxArray, vtxCount, idxArray, idxCount, box)' inSmalltalk:[false].
	result ifFalse:[^interpreterProxy primitiveFail].
	array _ interpreterProxy instantiateClass: interpreterProxy classArray indexableSize: 4.
	interpreterProxy storeInteger: 0 ofObject: array withValue: (box at: 0).
	interpreterProxy storeInteger: 1 ofObject: array withValue: (box at: 1).
	interpreterProxy storeInteger: 2 ofObject: array withValue: (box at: 2).
	interpreterProxy storeInteger: 3 ofObject: array withValue: (box at: 3).
	interpreterProxy failed ifTrue:[^nil].
	interpreterProxy pop: 7. "pop args + rcvr"
	interpreterProxy push: array.