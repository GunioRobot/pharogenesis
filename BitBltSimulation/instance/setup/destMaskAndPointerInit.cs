destMaskAndPointerInit
	"Compute masks for left and right destination words"
	| startBits pixPerM1 endBits |
	pixPerM1 _ pixPerWord - 1.  "A mask, assuming power of two"
	"how many pixels in first word"
	startBits _ pixPerWord - (dx bitAnd: pixPerM1).
	mask1 _ AllOnes >> (32 - (startBits*destPixSize)).
	"how many pixels in last word"
	endBits _ ((dx + bbW - 1) bitAnd: pixPerM1) + 1.
	mask2 _ AllOnes << (32 - (endBits*destPixSize)).
	"determine number of words stored per line; merge masks if only 1"
	bbW < startBits
		ifTrue: [mask1 _ mask1 bitAnd: mask2.
				mask2 _ 0.
				nWords _ 1]
		ifFalse: [nWords _ (bbW - startBits) + pixPerM1 // pixPerWord + 1].
	hDir _ vDir _ 1. "defaults for no overlap with source"

	"calculate byte addr and delta, based on first word of data"
	"Note raster and nwords are longs, not bytes"
	destIndex _ (destBits + 4) + (dy * destRaster + (dx // pixPerWord) *4).
	destDelta _ 4 * ((destRaster * vDir) - (nWords * hDir)).  "byte addr delta"