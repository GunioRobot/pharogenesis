ffiValidateExternalData: oop AtomicType: atomicType
	"Validate if the given oop (an instance of ExternalData) can be passed as a pointer to the given atomic type."
	| ptrType specOop spec specType |
	self inline: true.
	ptrType _ interpreterProxy fetchPointer: 1 ofObject: oop.
	(interpreterProxy isIntegerObject: ptrType)
		ifTrue:[^self ffiFail: FFIErrorWrongType].
	(interpreterProxy isPointers: ptrType)
		ifFalse:[^self ffiFail: FFIErrorWrongType].
	(interpreterProxy slotSizeOf: ptrType) < 2
		ifTrue:[^self ffiFail: FFIErrorWrongType].
	specOop _ interpreterProxy fetchPointer: 0 ofObject: ptrType.
	(interpreterProxy isIntegerObject: specOop)
		ifTrue:[^self ffiFail: FFIErrorWrongType].
	(interpreterProxy isWords: specOop)
		ifFalse:[^self ffiFail: FFIErrorWrongType].
	(interpreterProxy slotSizeOf: specOop) = 0
		ifTrue:[^self ffiFail: FFIErrorWrongType].
	spec _ interpreterProxy fetchWord: 0 ofObject: specOop.
	(self isAtomicType: spec)
		ifFalse:[^self ffiFail: FFIErrorWrongType].
	specType _ self atomicTypeOf: spec.
	specType ~= atomicType ifTrue:[
		"allow for signed/unsigned conversion but nothing else"
		(atomicType > FFITypeBool and:[atomicType < FFITypeSingleFloat])
			ifFalse:[^self ffiFail: FFIErrorCoercionFailed].
		((atomicType >> 1) = (specType >> 1))
			ifFalse:[^self ffiFail: FFIErrorCoercionFailed]].
	^0