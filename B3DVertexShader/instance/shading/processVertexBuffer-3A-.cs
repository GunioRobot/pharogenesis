processVertexBuffer: vb
	| colors emissionPart |
	colors _ B3DColor4Array new: vb vertexCount.
	"Load initial colors (e.g., emission part)"
	vb trackEmissionColor ifFalse:[
		emissionPart _ material emission.
		1 to: vb vertexCount do:[:i| colors at: i put: emissionPart].
	] ifTrue:[
		1 to: vb vertexCount do:[:i| colors at: i put: (vb primitiveVertexAt: i) b3dColor].
	].
	lights do:[:light|
		light shadeVertexBuffer: vb with: material into: colors.
	].
	colors clampAllFrom: 0.0 to: 1.0.
	vb vertexArray upTo: vb vertexCount doWithIndex:[:vtx :i| vtx color: (colors at: i)].
