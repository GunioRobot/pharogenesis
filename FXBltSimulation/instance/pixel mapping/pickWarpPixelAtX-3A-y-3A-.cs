pickWarpPixelAtX: x y: y
	"Pick a single pixel from the source for WarpBlt.
	Note: This method is crucial for WarpBlt speed w/o smoothing
	and still relatively important when smoothing is used."
	| srcIndex sourceWord sourcePix |
	self inline: true.
	"Fetch source word.
	Note: We should really update srcIndex with sx and sy so that
	we don't have to do the computation below. We might even be
	able to simplify the out of bounds test from above."
	srcIndex _ sourceBits + (y * sourcePitch) + (x >> warpAlignShift * 4).
	sourceWord _ self srcLongAt: srcIndex.

	"Extract pixel from word"
	srcBitShift _ warpBitShiftTable at: (x bitAnd: warpAlignMask).
	sourcePix _ sourceWord >> srcBitShift bitAnd: warpSrcMask.
	^sourcePix