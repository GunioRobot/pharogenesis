allocateWideBezier
	| bezier |
	(self allocateObjEntry: GBWideSize) ifFalse:[^0].
	bezier _ objUsed.
	objUsed _ bezier + GBWideSize.
	self objectTypeOf: bezier put: GEPrimitiveWideBezier.
	self objectIndexOf: bezier put: 0.
	self objectLengthOf: bezier put: GBWideSize.
	^bezier