allocateWideLine
	| line |
	(self allocateObjEntry: GLWideSize) ifFalse:[^0].
	line _ objUsed.
	objUsed _ line + GLWideSize.
	self objectTypeOf: line put: GEPrimitiveWideLine.
	self objectIndexOf: line put: 0.
	self objectLengthOf: line put: GLWideSize.
	^line