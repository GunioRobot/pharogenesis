loadRasterizerState: stackIndex
	"Load the rasterizer state from the given stack index."
	| stateOop obj objPtr objLen |
	self var: #objPtr declareC:'void *objPtr'.
	(copyBitsFn = 0 or:[loadBBFn = 0]) ifTrue:[
		"We need loadBitBltFrom/copyBits here so try to load it implicitly"
		self initialiseModule ifFalse:[^false].
	].
	stateOop _ interpreterProxy stackObjectValue: stackIndex.
	interpreterProxy failed ifTrue:[^false].
	((interpreterProxy isPointers: stateOop) and:[(interpreterProxy slotSizeOf: stateOop) >= 10])
		ifFalse:[^false].

	obj _ interpreterProxy fetchPointer: 0 ofObject: stateOop.
	((interpreterProxy isIntegerObject: obj) or:[(interpreterProxy isWords: obj) not])
		ifTrue:[^false].
	objPtr _ interpreterProxy firstIndexableField: obj.
	self cCode:'state.faceAlloc = objPtr'.

	obj _ interpreterProxy fetchPointer: 1 ofObject: stateOop.
	((interpreterProxy isIntegerObject: obj) or:[(interpreterProxy isWords: obj) not])
		ifTrue:[^false].
	objPtr _ interpreterProxy firstIndexableField: obj.
	self cCode:'state.edgeAlloc = objPtr'.

	obj _ interpreterProxy fetchPointer: 2 ofObject: stateOop.
	((interpreterProxy isIntegerObject: obj) or:[(interpreterProxy isWords: obj) not])
		ifTrue:[^false].
	objPtr _ interpreterProxy firstIndexableField: obj.
	self cCode:'state.attrAlloc = objPtr'.

	obj _ interpreterProxy fetchPointer: 3 ofObject: stateOop.
	((interpreterProxy isIntegerObject: obj) or:[(interpreterProxy isWords: obj) not])
		ifTrue:[^false].
	objPtr _ interpreterProxy firstIndexableField: obj.
	self cCode:'state.aet = objPtr'.

	obj _ interpreterProxy fetchPointer: 4 ofObject: stateOop.
	((interpreterProxy isIntegerObject: obj) or:[(interpreterProxy isWords: obj) not])
		ifTrue:[^false].
	objPtr _ interpreterProxy firstIndexableField: obj.
	self cCode:'state.addedEdges = objPtr'.

	obj _ interpreterProxy fetchPointer: 5 ofObject: stateOop.
	((interpreterProxy isIntegerObject: obj) or:[(interpreterProxy isWords: obj) not])
		ifTrue:[^false].
	objPtr _ interpreterProxy firstIndexableField: obj.
	self cCode:'state.fillList = objPtr'.

	obj _ interpreterProxy fetchPointer: 6 ofObject: stateOop.
	obj == interpreterProxy nilObject ifTrue:[
		self cCode:'state.nObjects = 0'.
		self cCode:'state.objects = NULL'.
	] ifFalse:[
		((interpreterProxy isIntegerObject: obj) or:[(interpreterProxy isWords: obj) not])
			ifTrue:[^false].
		objLen _ interpreterProxy slotSizeOf: obj.
		objPtr _ interpreterProxy firstIndexableField: obj.
		self cCode:'state.objects = (B3DPrimitiveObject **)objPtr'.
		self cCode:'state.nObjects = objLen'.
	].

	obj _ interpreterProxy fetchPointer: 7 ofObject: stateOop.
	obj == interpreterProxy nilObject ifTrue:[
		self cCode:'state.nTextures = 0'.
		self cCode:'state.textures = NULL'.
	] ifFalse:[
		((interpreterProxy isIntegerObject: obj) or:[(interpreterProxy isWords: obj) not])
			ifTrue:[^false].
		objLen _ interpreterProxy byteSizeOf: obj.
		objPtr _ interpreterProxy firstIndexableField: obj.
		self cCode:'state.textures = (B3DTexture *)objPtr'.
		self cCode:'state.nTextures = objLen / sizeof(B3DTexture)'.
	].

	obj _ interpreterProxy fetchPointer: 8 ofObject: stateOop.
	obj == interpreterProxy nilObject ifTrue:[
		self cCode:'state.spanSize = 0'.
		self cCode:'state.spanBuffer = NULL'.
	] ifFalse:[
		(interpreterProxy fetchClassOf: obj) == (interpreterProxy classBitmap)
			ifFalse:[^false].
		objLen _ interpreterProxy slotSizeOf: obj.
		objPtr _ interpreterProxy firstIndexableField: obj.
		self cCode:'state.spanBuffer = (unsigned int *)objPtr'.
		self cCode:'state.spanSize = objLen'.
	].

	obj _ interpreterProxy fetchPointer: 9 ofObject: stateOop.
	obj == interpreterProxy nilObject ifTrue:[
		self cCode:'state.spanDrawer = NULL'.
	] ifFalse:[
		(self cCode: '((int (*) (int))loadBBFn)(obj)') ifFalse:[^false].
		self cCode:'state.spanDrawer = (b3dDrawBufferFunction) copyBitsFn'.
	].

	^interpreterProxy failed not
