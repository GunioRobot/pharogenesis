destMaskAndPointerInit
	"Compute masks for left and right destination words"
	| startBits pixPerM1 endBits |
	self inline: true.
	pixPerM1 _ destPPW - 1.  "A mask, assuming power of two"
	"how many pixels in first word"
	startBits _ destPPW - (dx bitAnd: pixPerM1).
	destMSB
		ifTrue:[ mask1 _ AllOnes >> (32 - (startBits*destDepth))] 
		ifFalse:[ mask1 _ AllOnes << (32 - (startBits*destDepth))].
	"how many pixels in last word"
	endBits _ ((dx + bbW - 1) bitAnd: pixPerM1) + 1.
	destMSB 
		ifTrue:[mask2 _ AllOnes << (32 - (endBits*destDepth))] 
		ifFalse:[mask2 _ AllOnes >> (32 - (endBits*destDepth))].
	"determine number of words stored per line; merge masks if only 1"
	bbW < startBits
		ifTrue: [mask1 _ mask1 bitAnd: mask2.
				mask2 _ 0.
				nWords _ 1]
		ifFalse: [nWords _ (bbW - startBits) + pixPerM1 // destPPW + 1].
	hDir _ vDir _ 1. "defaults for no overlap with source"

	"calculate byte addr and delta, based on first word of data"
	"Note pitch is bytes and nWords is longs, not bytes"
	destIndex _ destBits + (dy * destPitch) + ((dx // destPPW) *4).
	destDelta _ destPitch * vDir - (4 * (nWords * hDir)).  "byte addr delta"
