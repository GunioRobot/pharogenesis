transformVB: vtxArray count: vtxCount by: modelViewMatrix and: projectionMatrix flags: flags
	"Transform the entire vertex array by the given matrices"
	"TODO: Check the actual trade-offs between vtxCount and analyzing"
	| mvFlags prFlags pVertex hasNormals rescale |
	self var: #projectionMatrix declareC:'float *projectionMatrix'.
	self var: #modelViewMatrix declareC:'float *modelViewMatrix'.
	self var: #vtxArray declareC:'float *vtxArray'.
	self var: #pVertex declareC:'float *pVertex'.

	"Analyze the matrices for better performance"
	mvFlags _ self analyzeMatrix: modelViewMatrix.
	prFlags _ self analyzeMatrix: projectionMatrix.

	pVertex _ self cCoerce: vtxArray to: 'float *'.
	hasNormals _ flags anyMask: VBVtxHasNormals.

	"Check if we have to rescale the normals"
	hasNormals ifTrue:[
		(mvFlags anyMask: FlagM44Identity)
			ifTrue:[rescale _ false]
			ifFalse:[rescale _ self analyzeMatrix3x3Length: modelViewMatrix]].

	"<---- NOTE: The most likely case goes first ---->"
	((mvFlags anyMask: FlagM44NoPerspective) and:[prFlags = 0]) ifTrue:[
		"Modelview matrix has no perspective part and projection is not optimized"
		(mvFlags = FlagM44NoTranslation) = 0 ifTrue:[
			"Modelview matrix with translation"
			1 to: vtxCount do:[:i|
				hasNormals ifTrue:[self transformPrimitiveNormal: pVertex by: modelViewMatrix rescale: rescale].
				self transformPrimitivePositionFast: pVertex by: modelViewMatrix.
				self transformPrimitiveRasterPosition: pVertex by: projectionMatrix.
				pVertex _ pVertex + PrimVertexSize].
		] ifFalse:[
			"Modelview matrix without translation"
			1 to: vtxCount do:[:i|
				hasNormals ifTrue:[self transformPrimitiveNormal: pVertex by: modelViewMatrix rescale: rescale].
				self transformPrimitivePositionFaster: pVertex by: modelViewMatrix.
				self transformPrimitiveRasterPosition: pVertex by: projectionMatrix.
				pVertex _ pVertex + PrimVertexSize].
		].
		^nil]. "done"
	"<---- End of most likely case ---->"

	((mvFlags bitAnd: prFlags) anyMask: FlagM44Identity) ifTrue:[
		"If both are identity matrices just copy entries"
		1 to: vtxCount do:[:i|
			pVertex at: PrimVtxRasterPosX put: (pVertex at: PrimVtxPositionX).
			pVertex at: PrimVtxRasterPosY put: (pVertex at: PrimVtxPositionY).
			pVertex at: PrimVtxRasterPosZ put: (pVertex at: PrimVtxPositionZ).
			pVertex at: PrimVtxRasterPosW put: 1.0.
			pVertex _ pVertex + PrimVertexSize].
		^nil]."done"

	(mvFlags anyMask: FlagM44Identity) ifTrue:[
		"If model view matrix is identity just perform projection"
		1 to: vtxCount do:[:i|
			self transformPrimitiveRasterPosition: pVertex by: projectionMatrix.
			pVertex _ pVertex + PrimVertexSize].
		^nil]. "done"

	"<--- modelview matrix not identity --->"

	(prFlags anyMask: FlagM44Identity) ifTrue:[
		"If projection matrix is identity just transform and copy.
		Note: This case is not very likely so it's not been unrolled."
		1 to: vtxCount do:[:i|
			hasNormals ifTrue:[self transformPrimitiveNormal: pVertex by: modelViewMatrix rescale: rescale].
			mvFlags = (FlagM44NoPerspective + FlagM44NoPerspective) ifTrue:[
				self transformPrimitivePositionFaster: pVertex by: modelViewMatrix.
			] ifFalse:[mvFlags = FlagM44NoPerspective ifTrue:[
				self transformPrimitivePositionFast: pVertex by: modelViewMatrix.
			] ifFalse:[
				self transformPrimitivePosition: pVertex by: modelViewMatrix.
			]].
			pVertex at: PrimVtxRasterPosX put: (pVertex at: PrimVtxPositionX).
			pVertex at: PrimVtxRasterPosY put: (pVertex at: PrimVtxPositionY).
			pVertex at: PrimVtxRasterPosZ put: (pVertex at: PrimVtxPositionZ).
			pVertex at: PrimVtxRasterPosW put: 1.0.
			pVertex _ pVertex + PrimVertexSize].
		^nil]. "done"

	"<----- None of the matrices is identity ---->"

	"Generic transformation"
	1 to: vtxCount do:[:i|
		hasNormals ifTrue:[self transformPrimitiveNormal: pVertex by: modelViewMatrix rescale: rescale].
		self transformPrimitivePosition: pVertex by: modelViewMatrix.
		self transformPrimitiveRasterPosition: pVertex by: projectionMatrix.
		pVertex _ pVertex + PrimVertexSize].