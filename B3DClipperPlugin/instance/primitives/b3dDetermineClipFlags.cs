b3dDetermineClipFlags
	"Primitive. Determine the clipping flags for all vertices."
	| vtxCount vtxArray result |
	self export: true.
	self inline: false.
	self var: #vtxArray declareC:'void *vtxArray'.
	interpreterProxy methodArgumentCount = 2
		ifFalse:[^interpreterProxy primitiveFail].
	vtxCount _ interpreterProxy stackIntegerValue: 0.
	interpreterProxy failed ifTrue:[^nil].
	vtxArray _ self stackPrimitiveVertexArray: 1 ofSize: vtxCount.
	(vtxArray == nil or:[interpreterProxy failed])
		ifTrue:[^interpreterProxy primitiveFail].
	result _ self determineClipFlags: vtxArray count: vtxCount.
	interpreterProxy failed ifFalse:[
		interpreterProxy pop: 3.
		interpreterProxy pushInteger: result.
	].