loadBitBltSourceForm
	"Load the source form for BitBlt. Return false if anything is wrong, true otherwise."
	| sourceBitsSize |
	self inline: true.
	sourceForm _ interpreterProxy fetchPointer: BBSourceFormIndex ofObject: bitBltOop.
	noSource _ self ignoreSourceOrHalftone: sourceForm.
	noSource ifTrue:[
		sourceX _ sourceY _ 0.
		^true].
	((interpreterProxy isPointers: sourceForm) and:[
		(interpreterProxy slotSizeOf: sourceForm) >= 4])
			ifFalse: [^ false].
	sourceX _ self fetchIntOrFloat: BBSourceXIndex ofObject: bitBltOop ifNil: 0.
	sourceY _ self fetchIntOrFloat: BBSourceYIndex ofObject: bitBltOop ifNil: 0.
	sourceBits _ interpreterProxy fetchPointer: FormBitsIndex ofObject: sourceForm.
	sourceWidth _ interpreterProxy fetchInteger: FormWidthIndex ofObject: sourceForm.
	sourceHeight _ interpreterProxy fetchInteger: FormHeightIndex ofObject: sourceForm.
	interpreterProxy failed ifTrue:[^false].
	(sourceWidth >= 0 and: [sourceHeight >= 0]) ifFalse: [^ false].
	sourceDepth _ interpreterProxy fetchInteger: FormDepthIndex ofObject: sourceForm.
	(sourceDepth bitAnd: sourceDepth-1) = 0 ifFalse:[^false].
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
		((interpreterProxy isWords: sourceBits) and:[
			(interpreterProxy fetchClassOf: sourceBits) = interpreterProxy classBitmap])
			ifTrue:[sourceMSB _ true]
			ifFalse:[sourceMSB _ false].
		"Skip header since external bits don't have one"
		sourceBits _ self cCoerce: (interpreterProxy firstIndexableField: sourceBits) to:'int'.
	].
	^true