primitiveSetTransform
	"Transform an entire vertex buffer using the supplied modelview and projection matrix."
	| projectionMatrix modelViewMatrix handle |
	self export: true.
	self inline: false.
	self var: #projectionMatrix declareC:'float *projectionMatrix'.
	self var: #modelViewMatrix declareC:'float *modelViewMatrix'.

	interpreterProxy methodArgumentCount = 3
		ifFalse:[^interpreterProxy primitiveFail].

	projectionMatrix _ self stackMatrix: 0.
	modelViewMatrix _ self stackMatrix: 1.
	handle _ interpreterProxy stackIntegerValue: 2.
	interpreterProxy failed ifTrue:[^nil].
	self cCode: 'b3dxSetTransform(handle, modelViewMatrix, projectionMatrix)'.
	^interpreterProxy pop: 3. "Leave rcvr on stack"