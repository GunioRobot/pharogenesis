allocateBitmapFill: cmSize colormap: cmBits
	| fill fillSize cm |
	self var:#cm declareC:'int *cm'.
	self var:#cmBits declareC:'int *cmBits'.
	fillSize _ GBMBaseSize + cmSize.
	(self allocateObjEntry: fillSize) ifFalse:[^0].
	fill _ objUsed.
	objUsed _ fill + fillSize.
	self objectTypeOf: fill put: GEPrimitiveClippedBitmapFill.
	self objectIndexOf: fill put: 0.
	self objectLengthOf: fill put: fillSize.
	cm _ self colormapOf: fill.
	self hasColorTransform ifTrue:[
		0 to: cmSize-1 do:[:i| cm at: i put: (self transformColor: (cmBits at: i))].
	] ifFalse:[
		0 to: cmSize-1 do:[:i| cm at: i put: (cmBits at: i)].
	].
	self bitmapCmSizeOf: fill put: cmSize.
	^fill