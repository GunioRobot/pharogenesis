b3dLoadVertexBuffer
	"Primitive. Load the data into the given vertex buffer.
	NOTE: dstStart is a zero-based index."
	| defaultVtx defaultNormal defaultTexCoords defaultColor count texPtr colorPtr normalPtr vtxPtr dstStart dstPtr pVtx |

	self export: true.
	self inline: false.

	self var: #defaultVtx declareC:'int *defaultVtx'.
	self var: #defaultNormal declareC:'int *defaultNormal'.
	self var: #defaultTexCoords declareC:'int *defaultTexCoords'.
	self var: #defaultColor declareC:'int *defaultColor'.

	self var: #texPtr declareC:'int *texPtr'.
	self var: #colorPtr declareC:'int *colorPtr'.
	self var: #normalPtr declareC:'int *normalPtr'.
	self var: #vtxPtr declareC:'int *vtxPtr'.
	self var: #dstPtr declareC:'int *dstPtr'.
	self var: #pVtx declareC:'int *pVtx'.

	defaultVtx _ self stackPrimitiveVertex: 0.
	count _ interpreterProxy stackIntegerValue: 1.
	texPtr _ self vbLoadArray: (interpreterProxy stackObjectValue: 2) 
				size: 2*count.
	colorPtr _ self vbLoadArray: (interpreterProxy stackObjectValue: 3) 
				size: count.
	normalPtr _ self vbLoadArray: (interpreterProxy stackObjectValue: 4) 
				size: 3*count.
	vtxPtr _ self vbLoadArray: (interpreterProxy stackObjectValue: 5) 
				size: 3*count.
	dstStart _ interpreterProxy stackIntegerValue: 6.
	dstPtr _ self stackPrimitiveVertexArray: 7 ofSize: dstStart + count.
	"Check for all problems above"
	(dstPtr = nil or:[defaultVtx == nil or:[interpreterProxy failed]]) 
		ifTrue:[^interpreterProxy primitiveFail].

	"Install default values"
	normalPtr = nil
		ifTrue:[defaultNormal _ defaultVtx + PrimVtxNormal]
		ifFalse:[defaultNormal _ normalPtr].
	texPtr = nil
		ifTrue:[defaultTexCoords _ defaultVtx + PrimVtxTexCoords]
		ifFalse:[defaultTexCoords _ texPtr].
	colorPtr = nil
		ifTrue:[defaultColor _ defaultVtx + PrimVtxColor32]
		ifFalse:[defaultColor _ colorPtr].
	"Do the actual stuff"
	pVtx _ dstPtr + (dstStart * PrimVertexSize).
	0 to: count-1 do:[:i|
		pVtx at: PrimVtxPositionX put: (vtxPtr at: 0).
		pVtx at: PrimVtxPositionY put: (vtxPtr at: 1).
		pVtx at: PrimVtxPositionZ put: (vtxPtr at: 2).
		pVtx at: PrimVtxNormalX put: (defaultNormal at: 0).
		pVtx at: PrimVtxNormalY put: (defaultNormal at: 1).
		pVtx at: PrimVtxNormalZ put: (defaultNormal at: 2).
		pVtx at: PrimVtxColor32 put: (defaultColor at: 0).
		pVtx at: PrimVtxTexCoordU put: (defaultTexCoords at: 0).
		pVtx at: PrimVtxTexCoordV put: (defaultTexCoords at: 1).
		"And go to the next vertex"
		pVtx _ pVtx + PrimVertexSize.
		vtxPtr _ vtxPtr + 3.
		normalPtr = nil ifFalse:[defaultNormal _ defaultNormal + 3].
		colorPtr = nil ifFalse:[defaultColor _ defaultColor + 1].
		texPtr = nil ifFalse:[defaultTexCoords _ defaultTexCoords + 2].
	].
	"Clean up stack"
	interpreterProxy pop: 9. "Pop args+rcvr"
	interpreterProxy pushInteger: count.