b3dTransformMatrixWithInto
	"Transform two matrices into the third"
	| m1 m2 m3 |
	self export: true.
	self inline: false.
	self var: #m1 declareC:'float *m1'.
	self var: #m2 declareC:'float *m2'.
	self var: #m3 declareC:'float *m3'.

	m3 _ self stackMatrix: 0.
	m2 _ self stackMatrix: 1.
	m1 _ self stackMatrix: 2.
	(m1 = nil) | (m2 = nil) | (m3 = nil) 
		ifTrue:[^interpreterProxy primitiveFail].
	m2 == m3 ifTrue:[^interpreterProxy primitiveFail].
	self transformMatrix: m1 with: m2 into: m3.
	interpreterProxy pop: 3. "Leave rcvr on stack"