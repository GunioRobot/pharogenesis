initEdgeTransform
	| transform |
	self inline: false.
	self var: #transform declareC:'float *transform'.
	transform _ self edgeTransform.
	transform at: 0 put: (self cCoerce: 1.0 to: 'float').
	transform at: 1 put: (self cCoerce: 0.0 to: 'float').
	transform at: 2 put: (self cCoerce: 0.0 to: 'float').
	transform at: 3 put: (self cCoerce: 0.0 to: 'float').
	transform at: 4 put: (self cCoerce: 1.0 to: 'float').
	transform at: 5 put: (self cCoerce: 0.0 to: 'float').
	self hasEdgeTransformPut: 0.