loadBitBltDestForm
	"Load the dest form for BitBlt. Return false if anything is wrong, true otherwise."
	| destBitsSize |
	self inline: true.
	destBits _ interpreterProxy fetchPointer: FormBitsIndex ofObject: destForm.
	destWidth _ interpreterProxy fetchInteger: FormWidthIndex ofObject: destForm.
	destHeight _ interpreterProxy fetchInteger: FormHeightIndex ofObject: destForm.
	(destWidth >= 0 and: [destHeight >= 0])
		ifFalse: [^ false].
	destDepth _ interpreterProxy fetchInteger: FormDepthIndex ofObject: destForm.
	destMSB _ destDepth > 0.
	destDepth < 0 ifTrue:[destDepth _ 0 - destDepth].
	"Ignore an integer bits handle for Display in which case 
	the appropriate values will be obtained by calling ioLockSurfaceBits()."
	(interpreterProxy isIntegerObject: destBits) ifTrue:[
		"Query for actual surface dimensions"
		(self queryDestSurface: (interpreterProxy integerValueOf: destBits))
			ifFalse:[^false].
		destPPW _ 32 // destDepth.
		destBits _ destPitch _ 0.
	] ifFalse:[
		destPPW _ 32 // destDepth.
		destPitch _ destWidth + (destPPW-1) // destPPW * 4.
		destBitsSize _ interpreterProxy byteSizeOf: destBits.
		((interpreterProxy isWordsOrBytes: destBits)
			and: [destBitsSize = (destPitch * destHeight)])
			ifFalse: [^ false].
		"Skip header since external bits don't have one"
		destBits _ self cCoerce: (interpreterProxy firstIndexableField: destBits) to:'int'.
	].
	^true