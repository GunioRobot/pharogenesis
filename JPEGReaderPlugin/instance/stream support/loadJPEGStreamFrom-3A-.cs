loadJPEGStreamFrom: streamOop
	| oop sz |
	(interpreterProxy slotSizeOf: streamOop) < 5 ifTrue:[^false].
	(interpreterProxy isPointers: streamOop) ifFalse:[^false].
	oop _ interpreterProxy fetchPointer: 0 ofObject: streamOop.
	(interpreterProxy isIntegerObject: oop) ifTrue:[^false].
	(interpreterProxy isBytes: oop) ifFalse:[^false].
	jsCollection _ interpreterProxy firstIndexableField: oop.
	sz _ interpreterProxy byteSizeOf: oop.
	jsPosition _ interpreterProxy fetchInteger: 1 ofObject: streamOop.
	jsReadLimit _ interpreterProxy fetchInteger: 2 ofObject: streamOop.
	jsBitBuffer _ interpreterProxy fetchInteger: 3 ofObject: streamOop.
	jsBitCount _ interpreterProxy fetchInteger: 4 ofObject: streamOop.
	interpreterProxy failed ifTrue:[^false].
	sz < jsReadLimit ifTrue:[^false].
	(jsPosition < 0 or:[jsPosition >= jsReadLimit]) ifTrue:[^false].
	^true