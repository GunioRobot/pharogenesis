ffiCreateReturnStruct
	"Generic callout support. Create a structure return value from an external function call"
	| retOop structSize oop |
	self inline: true.
	interpreterProxy failed ifTrue:[^nil].
	interpreterProxy pop: interpreterProxy methodArgumentCount+1.
	structSize _ ffiRetHeader bitAnd: FFIStructSizeMask.
	interpreterProxy pushRemappableOop: ffiRetClass.
	oop _ interpreterProxy 
			instantiateClass: interpreterProxy classByteArray 
			indexableSize: structSize.
	self ffiStore: (self cCoerce: (interpreterProxy firstIndexableField: oop) to:'int') 
		Structure: structSize.
	ffiRetClass _ interpreterProxy popRemappableOop.
	interpreterProxy pushRemappableOop: oop. "secure byte array"
	retOop _ interpreterProxy instantiateClass: ffiRetClass indexableSize: 0.
	oop _ interpreterProxy popRemappableOop.
	interpreterProxy storePointer: 0 ofObject: retOop withValue: oop.
	^interpreterProxy push: retOop.