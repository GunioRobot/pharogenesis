loadObjectsFrom: stackIndex
	| arrayOop arraySize objArray objOop objPtr |
	self var:#objArray declareC:'B3DPrimitiveObject **objArray'.
	self var:#objPtr declareC:'B3DPrimitiveObject *objPtr'.
	arrayOop _ interpreterProxy stackObjectValue: stackIndex.
	interpreterProxy failed ifTrue:[^nil].
	(interpreterProxy fetchClassOf: arrayOop) == (interpreterProxy classArray)
		ifFalse:[^interpreterProxy primitiveFail].
	arraySize _ interpreterProxy slotSizeOf: arrayOop.
	arraySize > (self cCode:'state.nObjects')
		ifTrue:[^interpreterProxy primitiveFail].
	objArray _ self cCode:'state.objects'.
	0 to: arraySize-1 do:[:i|
		objOop _ interpreterProxy fetchPointer: i ofObject: arrayOop.
		((interpreterProxy isIntegerObject: objOop) or:[(interpreterProxy isWords: objOop) not])
			ifTrue:[^interpreterProxy primitiveFail].
		objPtr _ self cCoerce: (interpreterProxy firstIndexableField: objOop) to:'B3DPrimitiveObject*'.
		(self cCode:'objPtr->magic != B3D_PRIMITIVE_OBJECT_MAGIC')
			ifTrue:[^interpreterProxy primitiveFail].
		self cCode:'objPtr->__oop__ = objOop'.
		objArray at: i put: objPtr.
	].