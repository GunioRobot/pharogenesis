primitiveComposeMatrix
	| m1 m2 m3 result |
	self export: true.
	self inline: false.
	self var: #m1 declareC:'float *m1'.
	self var: #m2 declareC:'float *m2'.
	self var: #m3 declareC:'float *m3'.
	m3 _ self loadArgumentMatrix: (result _ interpreterProxy stackObjectValue: 0).
	m2 _ self loadArgumentMatrix: (interpreterProxy stackObjectValue: 1).
	m1 _ self loadArgumentMatrix: (interpreterProxy stackObjectValue: 2).
	interpreterProxy failed ifTrue:[^nil].
	self matrix2x3ComposeMatrix: m1 with: m2 into: m3.
	interpreterProxy pop: 3.
	interpreterProxy push: result.