b3dComputeMinZ
	"Primitive. Compute and return the minimal z value of all objects in the vertex buffer."
	| idxSize vtxSize primType vtxArray idxArray minZ |
	self export: true.
	self inline: false.
	self var: #vtxArray declareC:'float *vtxArray'.
	self var: #idxArray declareC:'int *idxArray'.
	self var: #minZ declareC:'double minZ'.
	interpreterProxy methodArgumentCount = 5
		ifFalse:[^interpreterProxy primitiveFail].
	idxSize _ interpreterProxy stackIntegerValue: 0.
	vtxSize _ interpreterProxy stackIntegerValue: 2.
	primType _ interpreterProxy stackIntegerValue: 4.
	interpreterProxy failed ifTrue:[^nil].
	vtxArray _ self stackPrimitiveVertexArray: 3 ofSize: vtxSize.
	idxArray _ self stackPrimitiveIndexArray: 1 ofSize: idxSize validate: true forVertexSize: vtxSize.
	(vtxArray == nil or:[idxArray == nil or:[interpreterProxy failed]])
		ifTrue:[^interpreterProxy primitiveFail].
	(primType < 1 or:[primType > 6])
		ifTrue:[^interpreterProxy primitiveFail].
	primType <= 3 ifTrue:[
		minZ _ self processNonIndexed: vtxArray ofSize: vtxSize.
	] ifFalse:[
		minZ _ self processIndexed: vtxArray ofSize: vtxSize idxArray: idxArray idxSize: idxSize.
	].
	interpreterProxy failed ifFalse:[
		interpreterProxy pop: 6. "nArgs+rcvr"
		interpreterProxy pushFloat: minZ.
	].