ffiCreateReturnPointer: retVal
	"Generic callout support. Create a pointer return value from an external function call"
	| atomicType retOop oop ptr classOop |
	self var: #ptr declareC:'int *ptr'.
	interpreterProxy failed ifTrue:[^nil].
	interpreterProxy pop: interpreterProxy methodArgumentCount+1.
	(ffiRetClass == interpreterProxy nilObject) ifTrue:[
		"Create ExternalData upon return"
		atomicType _ self atomicTypeOf: ffiRetHeader.
		(atomicType >> 1) = (FFITypeSignedChar >> 1) ifTrue:["String return"
			^self ffiReturnCStringFrom: retVal].
		"generate external data"
		interpreterProxy pushRemappableOop: ffiRetOop.
		oop _ interpreterProxy 
				instantiateClass: interpreterProxy classExternalAddress 
				indexableSize: 4.
		ptr _ interpreterProxy firstIndexableField: oop.
		ptr at: 0 put: retVal.
		interpreterProxy pushRemappableOop: oop. "preserve for gc"
		retOop _ interpreterProxy 
				instantiateClass: interpreterProxy classExternalData 
				indexableSize: 0.
		oop _ interpreterProxy popRemappableOop. "external address"
		interpreterProxy storePointer: 0 ofObject: retOop withValue: oop.
		oop _ interpreterProxy popRemappableOop. "return type"
		interpreterProxy storePointer: 1 ofObject: retOop withValue: oop.
		^interpreterProxy push: retOop.
	].
	"non-atomic pointer return"
	interpreterProxy pushRemappableOop: ffiRetClass. "preserve for gc"
	(ffiRetHeader anyMask: FFIFlagStructure)
		ifTrue:[classOop _ interpreterProxy classByteArray]
		ifFalse:[classOop _ interpreterProxy classExternalAddress].
	oop _ interpreterProxy 
			instantiateClass: classOop
			indexableSize: 4.
	ptr _ interpreterProxy firstIndexableField: oop.
	ptr at: 0 put: retVal.
	ffiRetClass _ interpreterProxy popRemappableOop. "return class"
	interpreterProxy pushRemappableOop: oop. "preserve for gc"
	retOop _ interpreterProxy instantiateClass: ffiRetClass indexableSize: 0.
	oop _ interpreterProxy popRemappableOop. "external address"
	interpreterProxy storePointer: 0 ofObject: retOop withValue: oop.
	^interpreterProxy push: retOop.