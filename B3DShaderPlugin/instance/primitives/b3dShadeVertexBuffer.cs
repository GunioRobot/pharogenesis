b3dShadeVertexBuffer
	"Primitive. Shade all the vertices in the vertex buffer using the given array of primitive light sources. Return true on success."
	| lightArray vtxCount vtxArray lightCount |
	self export: true.
	self inline: false.
	self var: #vtxArray declareC:'float *vtxArray'.
	vbFlags _ interpreterProxy stackIntegerValue: 0.
	primMaterial _ self stackMaterialValue: 1.
	lightArray _ self stackLightArrayValue: 2.
	vtxCount _ interpreterProxy stackIntegerValue: 3.
	vtxArray _ self stackPrimitiveVertexArray: 4 ofSize: vtxCount.
	(vtxArray = nil or:[primMaterial = nil or:[interpreterProxy failed]])
		ifTrue:[^interpreterProxy primitiveFail].
	"Setup"
	litVertex _ vtxArray.
	lightCount _ interpreterProxy slotSizeOf: lightArray.
	"Go over all vertices"
	1 to: vtxCount do:[:i|
		"Load the primitive vertex"
		self loadPrimitiveVertex.
		"Load initial color (e.g., emissive part of vertex and/or material)"
		(vbFlags anyMask: VBTrackEmission) ifTrue:[
			"Load color from vertex"
			vtxOutColor at: 0 put: (vtxInColor at: 0) + (primMaterial at: EmissionRed).
			vtxOutColor at: 1 put: (vtxInColor at: 1) + (primMaterial at: EmissionGreen).
			vtxOutColor at: 2 put: (vtxInColor at: 2) + (primMaterial at: EmissionBlue).
			vtxOutColor at: 3 put: (vtxInColor at: 3) + (primMaterial at: EmissionAlpha).
		] ifFalse:[
			vtxOutColor at: 0 put: (primMaterial at: EmissionRed).
			vtxOutColor at: 1 put: (primMaterial at: EmissionGreen).
			vtxOutColor at: 2 put: (primMaterial at: EmissionBlue).
			vtxOutColor at: 3 put: (primMaterial at: EmissionAlpha).
		].
		"For each enabled light source"
		0 to: lightCount-1 do:[:j|
			"Fetch the light source"
			primLight _ self fetchLightSource: j ofObject: lightArray.
			"Setup values"
			self loadPrimitiveLightSource.
			"Compute the color from the light source"
			self shadeVertex.
		].
		"Store the computed color back"
		self storePrimitiveVertex.
		"And step on to the next vertex"
		litVertex _ litVertex + PrimVertexSize.
	].
	"Clean up stack"
	interpreterProxy pop: 6. "Pop args+rcvr"
	interpreterProxy pushBool: true.