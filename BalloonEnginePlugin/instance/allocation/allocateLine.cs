allocateLine
	| line |
	(self allocateObjEntry: GLBaseSize) ifFalse:[^0].
	line _ objUsed.
	objUsed _ line + GLBaseSize.
	self objectTypeOf: line put: GEPrimitiveLine.
	self objectIndexOf: line put: 0.
	self objectLengthOf: line put: GLBaseSize.
	^line