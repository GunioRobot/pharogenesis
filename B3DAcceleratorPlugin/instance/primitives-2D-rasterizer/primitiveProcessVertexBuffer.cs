primitiveProcessVertexBuffer
	| idxCount vtxCount vtxArray idxArray texHandle primType result |
	self export: true.
	self var: #idxArray type: 'int *'.
	self var: #vtxArray type: 'float *'.
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

	result _ self cCode:'b3dxRasterizeVertexBuffer(primType, texHandle, vtxArray, vtxCount, idxArray, idxCount)' inSmalltalk:[false].
	result ifFalse:[^interpreterProxy primitiveFail].
	interpreterProxy pop: 6. "pop args; return rcvr"