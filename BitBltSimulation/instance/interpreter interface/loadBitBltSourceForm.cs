loadBitBltSourceForm
	"Load the source form for BitBlt. Return false if anything is wrong, true otherwise."
	| sourceBitsSize |
	self inline: true.
	sourceBits _ interpreterProxy fetchPointer: FormBitsIndex ofObject: sourceForm.
	sourceWidth _ self fetchIntOrFloat: FormWidthIndex ofObject: sourceForm.
	sourceHeight _ self fetchIntOrFloat: FormHeightIndex ofObject: sourceForm.
	(sourceWidth >= 0 and: [sourceHeight >= 0])
		ifFalse: [^ false].
	sourceDepth _ interpreterProxy fetchInteger: FormDepthIndex ofObject: sourceForm.
	sourceMSB _ sourceDepth > 0.
	sourceDepth < 0 ifTrue:[sourceDepth _ 0 - sourceDepth].
	"Ignore an integer bits handle for Display in which case 
	the appropriate values will be obtained by calling ioLockSurfaceBits()."
	(interpreterProxy isIntegerObject: sourceBits) ifTrue:[
		"Query for actual surface dimensions"
		(self querySourceSurface: (interpreterProxy integerValueOf: sourceBits))
			ifFalse:[^false].
		sourcePPW _ 32 // sourceDepth.
		sourceBits _ sourcePitch _ 0.
	] ifFalse:[
		sourcePPW _ 32 // sourceDepth.
		sourcePitch _ sourceWidth + (sourcePPW-1) // sourcePPW * 4.
		sourceBitsSize _ interpreterProxy byteSizeOf: sourceBits.
		((interpreterProxy isWordsOrBytes: sourceBits)
			and: [sourceBitsSize = (sourcePitch * sourceHeight)])
			ifFalse: [^ false].
		"Skip header since external bits don't have one"
		sourceBits _ self cCoerce: (interpreterProxy firstIndexableField: sourceBits) to:'int'.
	].
	^true