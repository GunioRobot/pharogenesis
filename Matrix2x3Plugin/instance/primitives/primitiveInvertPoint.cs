primitiveInvertPoint
	| matrix |
	self export: true.
	self inline: false.
	self var: #matrix declareC:'float *matrix'.
	self loadArgumentPoint: (interpreterProxy stackObjectValue: 0).
	matrix _ self loadArgumentMatrix: (interpreterProxy stackObjectValue: 1).
	interpreterProxy failed ifTrue:[^nil].
	self matrix2x3InvertPoint: matrix.
	interpreterProxy failed ifFalse:[self roundAndStoreResultPoint: 2].