b3dTransformVertexBuffer
	"Transform an entire vertex buffer using the supplied modelview and projection matrix."
	| flags projectionMatrix modelViewMatrix vtxCount vtxArray |
	self export: true.
	self inline: false.
	self var: #projectionMatrix declareC:'float *projectionMatrix'.
	self var: #modelViewMatrix declareC:'float *modelViewMatrix'.
	self var: #vtxArray declareC:'float *vtxArray'.

	flags _ interpreterProxy stackIntegerValue: 0.
	projectionMatrix _ self stackMatrix: 1.
	modelViewMatrix _ self stackMatrix: 2.
	vtxCount _ interpreterProxy stackIntegerValue: 3.
	vtxArray _ self stackPrimitiveVertexArray: 4 ofSize: vtxCount.
	(projectionMatrix = nil) | (modelViewMatrix = nil) | (vtxArray = nil)
		ifTrue:[^interpreterProxy primitiveFail].
	interpreterProxy failed ifTrue:[^nil].
	self transformVB: vtxArray 
		count: vtxCount 
		by: modelViewMatrix 
		and: projectionMatrix 
		flags: flags.
	interpreterProxy pop: 5. "Leave rcvr on stack"