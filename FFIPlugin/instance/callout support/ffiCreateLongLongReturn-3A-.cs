ffiCreateLongLongReturn: isSigned
	"Create a longlong return value from a previous call out"
	| lowWord highWord largeClass nBytes largeInt ptr |
	self var: #ptr declareC:'unsigned char *ptr'.
	lowWord _ self ffiLongLongResultLow.
	highWord _ self ffiLongLongResultHigh.
	isSigned ifTrue:["check for 32 bit signed"
		(highWord = 0 and:[lowWord >= 0])
			ifTrue:[^interpreterProxy signed32BitIntegerFor: lowWord].
		(highWord = -1 and:[lowWord < 0])
			ifTrue:[^interpreterProxy signed32BitIntegerFor: lowWord].
		"negate value for negative longlong"
		highWord < 0 
			ifTrue:[	largeClass _ interpreterProxy classLargeNegativeInteger.
					lowWord _ lowWord bitInvert32.
					highWord _ highWord bitInvert32.
					lowWord = -1 "e.g., overflow when adding one"
						ifTrue:[highWord _ highWord + 1].
					lowWord _ lowWord + 1]
			ifFalse:[largeClass _ interpreterProxy classLargePositiveInteger].
			"fall through"
	] ifFalse:["check for 32 bit unsigned"
		highWord = 0 ifTrue:[
			^interpreterProxy positive32BitIntegerFor: lowWord].
		largeClass _ interpreterProxy classLargePositiveInteger.
		"fall through"
	].
	"Create LargeInteger result"
	nBytes _ 8.
	(highWord anyMask: 255 << 24) ifFalse:[
		nBytes _ 7.
		highWord < (1 << 16) ifTrue:[nBytes _ 6].
		highWord < (1 << 8) ifTrue:[nBytes _ 5].
		highWord = 0 ifTrue:[nBytes _ 4]].
	"now we know how many bytes to create"
	largeInt _ interpreterProxy instantiateClass: largeClass indexableSize: nBytes.
	(interpreterProxy isBytes: largeInt) 
		ifFalse:[^self ffiFail: FFIErrorBadReturn]. "Hossa!"
	ptr _ interpreterProxy firstIndexableField: largeInt.
	4 to: nBytes-1 do:[:i|
		ptr at: i put: (highWord >> (i-4*8) bitAnd: 255)].
	ptr at: 3 put: (lowWord >> 24 bitAnd: 255).
	ptr at: 2 put: (lowWord >> 16 bitAnd: 255).
	ptr at: 1 put: (lowWord >> 8 bitAnd: 255).
	ptr at: 0 put: (lowWord bitAnd: 255).
	^largeInt