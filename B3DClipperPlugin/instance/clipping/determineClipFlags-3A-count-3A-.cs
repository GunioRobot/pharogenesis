determineClipFlags: vtxArray count: count
	| vtxPtr fullMask w w2 flags x y z |
	self var: #vtxPtr declareC:'float *vtxPtr'.
	self var: #vtxArray declareC:'void *vtxArray'.
	self var: #x declareC:'double x'.
	self var: #y declareC:'double y'.
	self var: #z declareC:'double z'.
	self var: #w declareC:'double w'.
	self var: #w2 declareC:'double w2'.
	vtxPtr _ self cCoerce: vtxArray to: 'float *'.
	fullMask _ InAllMask + OutAllMask.
	1 to: count do:[:i|
		w _ vtxPtr at: PrimVtxRasterPosW.
		w2 _ 0.0 - w.
		flags _ 0.
		x _ vtxPtr at: PrimVtxRasterPosX.
		x >= w2 ifTrue:[flags _ flags bitOr: InLeftBit] ifFalse:[flags _ flags bitOr: OutLeftBit].
		x <= w ifTrue:[flags _ flags bitOr: InRightBit] ifFalse:[flags _ flags bitOr: OutRightBit].
		y _ vtxPtr at: PrimVtxRasterPosY.
		y >= w2 ifTrue:[flags _ flags bitOr: InBottomBit] ifFalse:[flags _ flags bitOr: OutBottomBit].
		y <= w ifTrue:[flags _ flags bitOr: InTopBit] ifFalse:[flags _ flags bitOr: OutTopBit].
		z _ vtxPtr at: PrimVtxRasterPosZ.
		z >= w2 ifTrue:[flags _ flags bitOr: InFrontBit] ifFalse:[flags _ flags bitOr: OutFrontBit].
		z <= w ifTrue:[flags _ flags bitOr: InBackBit] ifFalse:[flags _ flags bitOr: OutBackBit].
		fullMask _ fullMask bitAnd: flags.
		(self cCoerce: vtxPtr to:'int *') at: PrimVtxClipFlags put: flags.
		vtxPtr _ vtxPtr + PrimVertexSize.
	].
	^fullMask