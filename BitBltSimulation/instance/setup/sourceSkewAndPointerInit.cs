sourceSkewAndPointerInit
	"This is only used when source and dest are same depth,
	ie, when the barrel-shift copy loop is used."
	| dWid sxLowBits dxLowBits pixPerM1 |
	pixPerM1 _ pixPerWord - 1.  "A mask, assuming power of two"
	sxLowBits _ sx bitAnd: pixPerM1.
	dxLowBits _ dx bitAnd: pixPerM1.
	"check if need to preload buffer
	(i.e., two words of source needed for first word of destination)"
	hDir > 0 ifTrue:
		["n Bits stored in 1st word of dest"
		dWid _ bbW min: pixPerWord - dxLowBits.
		preload _ (sxLowBits + dWid) > pixPerM1]
	ifFalse:
		[dWid _ bbW min: dxLowBits + 1.
		preload _ (sxLowBits - dWid + 1) < 0].

	"calculate right-shift skew from source to dest"
	skew _ (sxLowBits - dxLowBits) * destPixSize.  " -32..32 "
	preload ifTrue: 
		[skew < 0
			ifTrue: [skew _ skew+32]
			ifFalse: [skew _ skew-32]].

	"Calc byte addr and delta from longWord info"
	sourceIndex _ (sourceBits + 4) + (sy * sourceRaster + (sx // (32//sourcePixSize)) *4).
	"calculate increments from end of 1 line to start of next"
	sourceDelta _ 4 * ((sourceRaster * vDir) - (nWords * hDir)).
	preload ifTrue:
		["Compensate for extra source word fetched"
		sourceDelta _ sourceDelta - (4*hDir)].