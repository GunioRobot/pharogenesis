b3dInitPrimitiveObject
	| vtxSize vtxArray idxSize idxArray primitive primOop primObj primSize textureIndex |
	self export: true.
	self inline: false.
	self var: #vtxArray declareC:'int *vtxArray'.
	self var: #idxArray declareC:'int *idxArray'.
	self var: #primObj declareC:'void *primObj'.
	"Check argument count"
	interpreterProxy methodArgumentCount = 8
		ifFalse:[^interpreterProxy primitiveFail].

	"Fetch the texture index"
	textureIndex _ interpreterProxy stackIntegerValue: 0.
	interpreterProxy failed ifTrue:[^nil].

	"Load the viewport"
	self loadViewportFrom: 1.
	interpreterProxy failed ifTrue:[^nil].

	"Fetch and validate the primitive vertex array"
	vtxSize _ interpreterProxy stackIntegerValue: 4.
	vtxArray _ self stackPrimitiveVertexArray: 5 ofSize: vtxSize.
	vtxArray = nil
		ifTrue:[^interpreterProxy primitiveFail].
	"Fetch and validate the primitive index array"
	idxSize _ interpreterProxy stackIntegerValue: 2.
	idxArray _ self stackPrimitiveIndexArray: 3 ofSize: idxSize validate: true forVertexSize: vtxSize.
	idxArray = nil
		ifTrue:[^interpreterProxy primitiveFail].

	"Fetch and validate the primitive type"
	primitive _ interpreterProxy stackIntegerValue: 6.
	(primitive < 1 or:[primitive > PrimTypeMax]) 
		ifTrue:[^interpreterProxy primitiveFail].

	"For now we only support indexed triangles, quads and polys"
	(primitive = 3 or:[primitive = 5 or:[primitive = 6]]) ifFalse:[^interpreterProxy primitiveFail].

	"Load the primitive object"
	primOop _ interpreterProxy stackObjectValue: 7.
	interpreterProxy failed ifTrue:[^nil].
	(interpreterProxy isWords: primOop)
		ifFalse:[^interpreterProxy primitiveFail].
	primObj _ interpreterProxy firstIndexableField: primOop.
	primSize _ interpreterProxy byteSizeOf: primOop.

	"Do the work"
	primitive = 3 ifTrue:[
		(self cCode: 'b3dAddPolygonObject((void*) primObj, primSize, B3D_FACE_RGB, textureIndex, (B3DPrimitiveVertex*) vtxArray, vtxSize, &viewport) != B3D_NO_ERROR')
			ifTrue:[^interpreterProxy primitiveFail].
	].
	primitive = 5 ifTrue:[
		(self cCode:'b3dAddIndexedTriangleObject((void*) primObj, primSize, B3D_FACE_RGB, textureIndex, (B3DPrimitiveVertex*) vtxArray, vtxSize, (B3DInputFace*) idxArray, idxSize / 3, &viewport) != B3D_NO_ERROR') 
			ifTrue:[^interpreterProxy primitiveFail].
	].
	primitive = 6 ifTrue:[
		(self cCode:'b3dAddIndexedQuadObject((void*) primObj, primSize, B3D_FACE_RGB, textureIndex, (B3DPrimitiveVertex*) vtxArray, vtxSize, (B3DInputQuad*) idxArray, idxSize / 4, &viewport) != B3D_NO_ERROR')
			ifTrue:[^interpreterProxy primitiveFail].
	].
	"Pop args+rcvr; return primitive object"
	interpreterProxy pop: 9.
	interpreterProxy push: primOop.