floatObjectOf: aFloat
	| newFloatObj |
	self var: #aFloat declareC: 'double aFloat'.
	newFloatObj _ self instantiateSmallClass: (self splObj: ClassFloat) sizeInBytes: 12 fill: 0.
	self storeFloatAt: newFloatObj + BaseHeaderSize from: aFloat.
	^ newFloatObj.
