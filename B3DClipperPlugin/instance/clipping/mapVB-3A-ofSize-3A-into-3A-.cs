mapVB: vtxArray ofSize: vtxCount into: boxArray
	| left right top bottom vtxPtr flags w x y oop floatOop |
	self var: #vtxPtr declareC:'float *vtxPtr'.
	self var: #vtxArray declareC:'void *vtxArray'.
	self var: #x declareC:'double x'.
	self var: #y declareC:'double y'.
	self var: #w declareC:'double w'.
	self var: #left declareC:'double left'.
	self var: #right declareC:'double right'.
	self var: #top declareC:'double top'.
	self var: #bottom declareC:'double bottom'.

	vtxPtr _ self cCoerce: vtxArray to: 'float *'.

	1 to: vtxCount do:[:i|
		flags _ (self cCoerce: vtxPtr to:'int *') at: PrimVtxClipFlags.
		w _ vtxPtr at: PrimVtxRasterPosW.
		w = 0.0 ifFalse:[w _ 1.0 / w].
		(flags bitAnd: OutLeftBit) ~= 0
			ifTrue:[x _ -1.0]
			ifFalse:[(flags bitAnd: OutRightBit) ~= 0
				ifTrue:[x _ 1.0]
				ifFalse:[x _ (vtxPtr at: PrimVtxRasterPosX) * w]].
		(flags bitAnd: OutTopBit) ~= 0
			ifTrue:[y _ -1.0]
			ifFalse:[(flags bitAnd: OutBottomBit) ~= 0
				ifTrue:[y _ 1.0]
				ifFalse:[y _ (vtxPtr at: PrimVtxRasterPosY) * w]].
		i = 1 ifTrue:[
			left _ right _ x.
			top _ bottom _ y.
		].
		x < left ifTrue:[left _ x].
		x > right ifTrue:[right _ x].
		y < top ifTrue:[top _ y].
		y > bottom ifTrue:[bottom _ y].
		vtxPtr _ vtxPtr + PrimVertexSize.
	].
	oop _ boxArray.

	interpreterProxy pushRemappableOop: oop.
	floatOop _ interpreterProxy floatObjectOf: left.
	oop _ interpreterProxy popRemappableOop.
	interpreterProxy storePointer: 0 ofObject: oop withValue: floatOop.

	interpreterProxy pushRemappableOop: oop.
	floatOop _ interpreterProxy floatObjectOf: top.
	oop _ interpreterProxy popRemappableOop.
	interpreterProxy storePointer: 1 ofObject: oop withValue: floatOop.

	interpreterProxy pushRemappableOop: oop.
	floatOop _ interpreterProxy floatObjectOf: right.
	oop _ interpreterProxy popRemappableOop.
	interpreterProxy storePointer: 2 ofObject: oop withValue: floatOop.

	interpreterProxy pushRemappableOop: oop.
	floatOop _ interpreterProxy floatObjectOf: bottom.
	oop _ interpreterProxy popRemappableOop.
	interpreterProxy storePointer: 3 ofObject: oop withValue: floatOop.