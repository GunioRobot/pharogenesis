ffiCheckReturn: retSpec With: retClass
	"Make sure we can return an object of the given type"
	self inline: true.
	retClass == interpreterProxy nilObject ifFalse:[
		(interpreterProxy includesBehavior: retClass 
						ThatOf: interpreterProxy classExternalStructure)
			ifFalse:[^self ffiFail: FFIErrorBadReturn]].
	ffiRetClass _ retClass.

	(interpreterProxy isIntegerObject: retSpec)
		ifTrue:[self ffiFail: FFIErrorWrongType. ^nil].
	(interpreterProxy isWords: retSpec)
		ifFalse:[self ffiFail: FFIErrorWrongType. ^nil].
	ffiRetSpecSize _ interpreterProxy slotSizeOf: retSpec.
	ffiRetSpecSize = 0 ifTrue:[self ffiFail: FFIErrorWrongType. ^nil].
	ffiRetSpec _ self cCoerce: (interpreterProxy firstIndexableField: retSpec) to: 'int'.
	ffiRetHeader _ interpreterProxy longAt: ffiRetSpec.
	(self isAtomicType: ffiRetHeader) ifFalse:[
		(ffiRetClass == interpreterProxy nilObject)
			ifTrue:[^self ffiFail: FFIErrorBadReturn]].
	(self ffiCan: (self cCoerce: ffiRetSpec to:'int*') Return: ffiRetSpecSize)
		ifFalse:[self ffiFail: FFIErrorBadReturn]. "cannot return this type"
	^0