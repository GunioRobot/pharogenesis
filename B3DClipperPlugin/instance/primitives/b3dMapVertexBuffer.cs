b3dMapVertexBuffer
	"Primitive. Determine the bounds for all vertices in the vertex buffer."
	| vtxCount vtxArray boxArray |
	self export: true.
	self inline: false.
	self var: #vtxArray declareC:'void *vtxArray'.
	interpreterProxy methodArgumentCount = 3
		ifFalse:[^interpreterProxy primitiveFail].
	boxArray _ interpreterProxy stackObjectValue: 0.
	interpreterProxy failed ifTrue:[^nil].
	((interpreterProxy fetchClassOf: boxArray) = interpreterProxy classArray
		and:[(interpreterProxy slotSizeOf: boxArray) = 4])
			ifFalse:[^interpreterProxy primitiveFail].
	vtxCount _ interpreterProxy stackIntegerValue: 1.
	interpreterProxy failed ifTrue:[^nil].
	vtxArray _ self stackPrimitiveVertexArray: 2 ofSize: vtxCount.
	(vtxArray == nil or:[interpreterProxy failed])
		ifTrue:[^interpreterProxy primitiveFail].
	self mapVB: vtxArray ofSize: vtxCount into: boxArray.
	interpreterProxy failed ifFalse:[
		interpreterProxy pop: 3. "pop args; return rcvr"
	].