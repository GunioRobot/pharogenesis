ffiPushSignedLongLongOop: oop
	"Push a longlong type (e.g., a 64bit integer).
	Note: Coercions from float are *not* supported."
	| lowWord highWord length oopClass negative ptr |
	self var: #ptr declareC:'unsigned char *ptr'.
	oop == interpreterProxy nilObject 
		ifTrue:[^self ffiPushSignedLong: 0 Long: 0.]. "@@: check this"
	oop == interpreterProxy falseObject
		ifTrue:[^self ffiPushSignedLong: 0 Long: 0].
	oop == interpreterProxy trueObject
		ifTrue:[^self ffiPushSignedLong: 0 Long: 1].
	(interpreterProxy isIntegerObject: oop) ifTrue:[
		lowWord _ interpreterProxy integerValueOf: oop.
		lowWord < 0 
			ifTrue:[highWord _ -1]
			ifFalse:[highWord _ 0].
	] ifFalse:[
		oopClass _ interpreterProxy fetchClassOf: oop.
		oopClass == interpreterProxy classLargePositiveInteger 
			ifTrue:[negative _ false]
			ifFalse:[oopClass == interpreterProxy classLargeNegativeInteger 
				ifTrue:[negative _ true]
				ifFalse:[^self ffiFail: FFIErrorCoercionFailed]].
		(interpreterProxy isBytes: oop) ifFalse:[^self ffiFail: FFIErrorCoercionFailed].
		length _ interpreterProxy byteSizeOf: oop.
		length > 8 ifTrue:[^self ffiFail: FFIErrorCoercionFailed].
		lowWord _ highWord _ 0.
		ptr _ interpreterProxy firstIndexableField: oop.
		0 to: (length min: 4)-1 do:[:i|
			lowWord _ lowWord + ((ptr at: i) << (i*8))].
		0 to: (length-5) do:[:i|
			highWord _ highWord + ((ptr at: i+4) << (i*8))].
		negative ifTrue:[
			lowWord _ lowWord bitInvert32.
			highWord _ highWord bitInvert32.
			lowWord = -1 "e.g., will overflow when adding one"
				ifTrue:[highWord _ highWord + 1].
			lowWord _ lowWord + 1].
	].
	^self ffiPushSignedLong: lowWord Long: highWord.