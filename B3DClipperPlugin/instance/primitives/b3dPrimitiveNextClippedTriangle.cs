b3dPrimitiveNextClippedTriangle
	"Primitive. Return the next clipped triangle from the vertex buffer and return its index."
	| idxCount vtxCount firstIndex vtxArray idxArray idx1 idx2 idx3 triMask |
	self export: true.
	self inline: false.
	self var: #idxArray declareC:'int *idxArray'.
	self var: #vtxArray declareC:'int *vtxArray'.
	interpreterProxy methodArgumentCount = 5
		ifFalse:[^interpreterProxy primitiveFail].
	idxCount _ interpreterProxy stackIntegerValue: 0.
	vtxCount _ interpreterProxy stackIntegerValue: 2.
	firstIndex _ interpreterProxy stackIntegerValue: 4.
	interpreterProxy failed ifTrue:[^nil].
	vtxArray _ self stackPrimitiveVertexArray: 3 ofSize: vtxCount.
	idxArray _ self stackPrimitiveIndexArray: 1 ofSize: idxCount validate: true forVertexSize: vtxCount.
	(vtxArray == nil or:[idxArray == nil or:[interpreterProxy failed]])
		ifTrue:[^interpreterProxy primitiveFail].

	"Hack idxArray and vtxArray for 1-based indexes"
	idxArray _ idxArray - 1.
	vtxArray _ vtxArray - PrimVertexSize.
	firstIndex to: idxCount by: 3 do:[:i|
		idx1 _ idxArray at: i.
		idx2 _ idxArray at: i+1.
		idx3 _ idxArray at: i+2.
		(idx1 == 0 or:[idx2 == 0 or:[idx3 == 0]]) ifFalse:[
			triMask _ ((vtxArray at: idx1 * PrimVertexSize + PrimVtxClipFlags) bitAnd:
						((vtxArray at: idx2 * PrimVertexSize + PrimVtxClipFlags) bitAnd:
						(vtxArray at: idx3 * PrimVertexSize + PrimVtxClipFlags))).
			"Check if tri is completely inside"
			(InAllMask bitAnd: triMask) = InAllMask ifFalse:[
				"Tri is not completely inside -> needs clipping."
				(triMask anyMask: OutAllMask) ifTrue:[
					"tri is completely outside. Store all zeros"
					idxArray at: i put: 0.
					idxArray at: i+1 put: 0.
					idxArray at: i+2 put: 0.
				] ifFalse:[
					"tri must be partially clipped."
					interpreterProxy pop: 6. "args + rcvr"
					interpreterProxy pushInteger: i.
					^nil
				].
			].
		].
	].
	"No more entries"
	interpreterProxy pop: 6. "args + rcvr"
	interpreterProxy pushInteger: 0.
