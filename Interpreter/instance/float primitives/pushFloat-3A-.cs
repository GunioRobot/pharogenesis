pushFloat: f

	| newFloatObj |
	self var: #f declareC: 'double f'.
	newFloatObj _ self instantiateSmallClass: (self splObj: ClassFloat) sizeInBytes: 12 fill: 0.
	self storeFloatAt: newFloatObj + BaseHeaderSize from: f.
	self push: newFloatObj.