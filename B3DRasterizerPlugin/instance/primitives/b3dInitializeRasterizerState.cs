b3dInitializeRasterizerState
	"Primitive. Initialize the primitive level objects of the given rasterizer."
	| stateOop objOop objLen obj |
	self export: true.
	self inline: false.
	self var: #obj declareC:'void *obj'.

	"Check argument count"
	interpreterProxy methodArgumentCount = 0
		ifFalse:[^interpreterProxy primitiveFail].

	stateOop _ interpreterProxy stackObjectValue: 0.
	interpreterProxy failed ifTrue:[^nil].
	((interpreterProxy isPointers: stateOop) and:[(interpreterProxy slotSizeOf: stateOop) >= 7])
		ifFalse:[^interpreterProxy primitiveFail].

	objOop _ interpreterProxy fetchPointer: 0 ofObject: stateOop.
	((interpreterProxy isIntegerObject: objOop) or:[(interpreterProxy isWords: objOop)  not])
		ifTrue:[^interpreterProxy primitiveFail].
	objLen _ interpreterProxy byteSizeOf: objOop.
	obj _ interpreterProxy firstIndexableField: objOop.
	(self cCode: 'b3dInitializeFaceAllocator(obj, objLen) != B3D_NO_ERROR') 
		ifTrue:[^interpreterProxy primitiveFail].

	objOop _ interpreterProxy fetchPointer: 1 ofObject: stateOop.
	((interpreterProxy isIntegerObject: objOop) or:[(interpreterProxy isWords: objOop)  not])
		ifTrue:[^interpreterProxy primitiveFail].
	objLen _ interpreterProxy byteSizeOf: objOop.
	obj _ interpreterProxy firstIndexableField: objOop.
	(self cCode: 'b3dInitializeEdgeAllocator(obj, objLen) != B3D_NO_ERROR') 
		ifTrue:[^interpreterProxy primitiveFail].

	objOop _ interpreterProxy fetchPointer: 2 ofObject: stateOop.
	((interpreterProxy isIntegerObject: objOop) or:[(interpreterProxy isWords: objOop)  not])
		ifTrue:[^interpreterProxy primitiveFail].
	objLen _ interpreterProxy byteSizeOf: objOop.
	obj _ interpreterProxy firstIndexableField: objOop.
	(self cCode: 'b3dInitializeAttrAllocator(obj, objLen) != B3D_NO_ERROR') 
		ifTrue:[^interpreterProxy primitiveFail].

	objOop _ interpreterProxy fetchPointer: 3 ofObject: stateOop.
	((interpreterProxy isIntegerObject: objOop) or:[(interpreterProxy isWords: objOop)  not])
		ifTrue:[^interpreterProxy primitiveFail].
	objLen _ interpreterProxy byteSizeOf: objOop.
	obj _ interpreterProxy firstIndexableField: objOop.
	(self cCode: 'b3dInitializeAET(obj, objLen) != B3D_NO_ERROR') 
		ifTrue:[^interpreterProxy primitiveFail].

	objOop _ interpreterProxy fetchPointer: 4 ofObject: stateOop.
	((interpreterProxy isIntegerObject: objOop) or:[(interpreterProxy isWords: objOop)  not])
		ifTrue:[^interpreterProxy primitiveFail].
	objLen _ interpreterProxy byteSizeOf: objOop.
	obj _ interpreterProxy firstIndexableField: objOop.
	(self cCode: 'b3dInitializeEdgeList(obj, objLen) != B3D_NO_ERROR') 
		ifTrue:[^interpreterProxy primitiveFail].

	objOop _ interpreterProxy fetchPointer: 5 ofObject: stateOop.
	((interpreterProxy isIntegerObject: objOop) or:[(interpreterProxy isWords: objOop)  not])
		ifTrue:[^interpreterProxy primitiveFail].
	objLen _ interpreterProxy byteSizeOf: objOop.
	obj _ interpreterProxy firstIndexableField: objOop.
	(self cCode: 'b3dInitializeFillList(obj, objLen) != B3D_NO_ERROR') 
		ifTrue:[^interpreterProxy primitiveFail].

	"Don't pop anything - return the receiver"