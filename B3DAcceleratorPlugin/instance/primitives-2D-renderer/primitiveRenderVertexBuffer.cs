primitiveRenderVertexBuffer
	| idxCount vtxCount vtxArray idxArray texHandle primType result flags handle |
	self export: true.
	self var: #idxArray type: 'int *'.
	self var: #vtxArray type: 'float *'.

	interpreterProxy methodArgumentCount = 8
		ifFalse:[^interpreterProxy primitiveFail].
	idxCount _ interpreterProxy stackIntegerValue: 0.
	vtxCount _ interpreterProxy stackIntegerValue: 2.
	texHandle _ interpreterProxy stackIntegerValue: 4.
	flags _ interpreterProxy stackIntegerValue: 5.
	primType _ interpreterProxy stackIntegerValue: 6.
	handle _ interpreterProxy stackIntegerValue: 7.

	interpreterProxy failed ifTrue:[^nil].
	vtxArray _ self stackPrimitiveVertexArray: 3 ofSize: vtxCount.
	idxArray _ self stackPrimitiveIndexArray: 1 ofSize: idxCount validate: true forVertexSize: vtxCount.

	(vtxArray == nil or:[idxArray == nil 
		or:[primType < 1 or:[primType > PrimTypeMax 
			or:[interpreterProxy failed]]]])
				ifTrue:[^interpreterProxy primitiveFail].

	result _ self cCode:'b3dxRenderVertexBuffer(handle, primType, flags, texHandle, vtxArray, vtxCount, idxArray, idxCount)' inSmalltalk:[false].
	result ifFalse:[^interpreterProxy primitiveFail].
	^interpreterProxy pop: 8. "pop args; return rcvr"