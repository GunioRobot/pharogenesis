loadBitBltSourceForm
	"Load the source form for BitBlt. Return false if anything is wrong, true otherwise."
	| sourcePixPerWord sourceBitsSize |
	self inline: true.
	sourceBits _ interpreterProxy fetchPointer: FormBitsIndex ofObject: sourceForm.
	srcWidth _ self fetchIntOrFloat: FormWidthIndex ofObject: sourceForm.
	srcHeight _ self fetchIntOrFloat: FormHeightIndex ofObject: sourceForm.
	(srcWidth >= 0 and: [srcHeight >= 0])
		ifFalse: [^ false].
	sourcePixSize _ interpreterProxy fetchInteger: FormDepthIndex ofObject: sourceForm.
	"Ignore an integer bits handle for Display in which case 
	the appropriate values will be obtained by calling ioLockSurfaceBits()."
	(interpreterProxy isIntegerObject: sourceBits) ifTrue:[
		"Query for actual surface dimensions"
		(self querySourceSurface: (interpreterProxy integerValueOf: sourceBits))
			ifFalse:[^false].
		sourcePixPerWord _ 32 // sourcePixSize.
		sourceBits _ sourcePitch _ 0.
	] ifFalse:[
		sourcePixPerWord _ 32 // sourcePixSize.
		sourcePitch _ srcWidth + (sourcePixPerWord-1) // sourcePixPerWord * 4.
		sourceBitsSize _ interpreterProxy byteSizeOf: sourceBits.
		((interpreterProxy isWordsOrBytes: sourceBits)
			and: [sourceBitsSize = (sourcePitch * srcHeight)])
			ifFalse: [^ false].
		"Skip header since external bits don't have one"
		sourceBits _ self cCoerce: (interpreterProxy firstIndexableField: sourceBits) to:'int'.
	].
	^true