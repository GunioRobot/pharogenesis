b3dTransformPrimitivePosition
	"Transform the position of the given primitive vertex the given matrix
	and store the result back inplace."
	| pVertex matrix |
	self export: true.
	self inline: false.
	self var: #matrix declareC:'float *matrix'.
	self var: #pVertex declareC:'float *pVertex'.

	matrix _ self stackMatrix: 0.
	pVertex _ self stackPrimitiveVertex: 1.
	(matrix = nil) | (pVertex = nil) 
		ifTrue:[^interpreterProxy primitiveFail].
	self transformPrimitivePosition: pVertex by: matrix.
	interpreterProxy pop: 2. "Leave rcvr on stack"