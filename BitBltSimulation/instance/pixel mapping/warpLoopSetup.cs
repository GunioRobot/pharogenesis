warpLoopSetup
	"Setup values for faster pixel fetching."
	| words |
	self inline: true.

	"warpSrcShift = log2(sourceDepth)"
	warpSrcShift _ 0.
	words _ sourceDepth. "recycle temp"
	[words = 1] whileFalse:[
		warpSrcShift _ warpSrcShift + 1.
		words _ words >> 1].

	"warpSrcMask = mask for extracting one pixel from source word"
	warpSrcMask _ maskTable at: sourceDepth.

	"warpAlignShift: Shift for aligning x position to word boundary"
	warpAlignShift _ 5 - warpSrcShift.

	"warpAlignMask: Mask for extracting the pixel position from an x position"
	warpAlignMask _ 1 << warpAlignShift - 1.

	"Setup the lookup table for source bit shifts"
	"warpBitShiftTable: given an sub-word x value what's the bit shift?"
	0 to: warpAlignMask do:[:i|
		sourceMSB
			ifTrue:[warpBitShiftTable at: i put: 32 - ( i + 1 << warpSrcShift )]
			ifFalse:[warpBitShiftTable at: i put: (i << warpSrcShift)]].
