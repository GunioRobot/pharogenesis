ffiAtomicStructByReference: oop Class: oopClass
	"Support for generic callout. Prepare an external pointer reference to an atomic type for callout."
	| atomicType valueOop |
	self inline: true.
	"must be external data to pass pointers to atomic type"
	oopClass == interpreterProxy classExternalData 
		ifFalse:[^self ffiFail: FFIErrorCoercionFailed].
	atomicType _ self atomicTypeOf: ffiArgHeader.
	"no type checks for void pointers"
	atomicType ~= FFITypeVoid ifTrue:[
		self ffiValidateExternalData: oop AtomicType: atomicType.
		interpreterProxy failed ifTrue:[^nil].
	].
	"and push pointer contents"
	valueOop _ interpreterProxy fetchPointer: 0 ofObject: oop.
	^self ffiPushPointerContentsOf: valueOop