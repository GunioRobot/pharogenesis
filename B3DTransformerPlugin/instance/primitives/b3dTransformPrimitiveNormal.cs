b3dTransformPrimitiveNormal
	"Transform the normal of the given primitive vertex using the argument matrix and rescale the normal if necessary."
	| pVertex matrix rescale |
	self export: true.
	self inline: false.
	self var: #matrix declareC:'float *matrix'.
	self var: #pVertex declareC:'float *pVertex'.

	rescale _ interpreterProxy stackValue: 0.
	rescale == interpreterProxy nilObject 
		ifFalse:[rescale _ interpreterProxy booleanValueOf: rescale].
	matrix _ self stackMatrix: 1.
	pVertex _ self stackPrimitiveVertex: 2.
	(matrix = nil) | (pVertex = nil) 
		ifTrue:[^interpreterProxy primitiveFail].
	(rescale ~~ true and:[rescale ~~ false])
		ifTrue:[rescale _ self analyzeMatrix3x3Length: matrix].
	self transformPrimitiveNormal: pVertex by: matrix rescale: rescale.
	interpreterProxy pop: 3. "Leave rcvr on stack"