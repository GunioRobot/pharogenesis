xWarpLoop
	"This version of the inner loop traverses an arbirary quadrilateral
	source, thus producing a general affine transformation."
	| skewWord halftoneWord mergeWord startBits
	  deltaP12x deltaP12y deltaP43x deltaP43y pAx pAy pBx pBy
	  xDelta yDelta smoothingCount sourceMapOop 
	  nSteps nPix words destWord endBits mergeFnwith |
	self inline: false.
	self var: #mergeFnwith declareC: 'int (*mergeFnwith)(int, int)'.
	mergeFnwith _ self cCoerce: (opTable at: combinationRule+1) to: 'int (*)(int, int)'.
	mergeFnwith.  "null ref for compiler"
 
	(interpreterProxy slotSizeOf: bitBltOop) >= (BBWarpBase+12)
		ifFalse: [^ interpreterProxy primitiveFail].
	nSteps _ height-1.  nSteps <= 0 ifTrue: [nSteps _ 1].

	pAx _ self fetchIntOrFloat: BBWarpBase ofObject: bitBltOop.
	words _ self fetchIntOrFloat: BBWarpBase+3 ofObject: bitBltOop.
	deltaP12x _ self deltaFrom: pAx to: words nSteps: nSteps.
	deltaP12x < 0 ifTrue: [pAx _ words - (nSteps*deltaP12x)].

	pAy _ self fetchIntOrFloat: BBWarpBase+1 ofObject: bitBltOop.
	words _ self fetchIntOrFloat: BBWarpBase+4 ofObject: bitBltOop.
	deltaP12y _ self deltaFrom: pAy to: words nSteps: nSteps.
	deltaP12y < 0 ifTrue: [pAy _ words - (nSteps*deltaP12y)].

	pBx _ self fetchIntOrFloat: BBWarpBase+9 ofObject: bitBltOop.
	words _ self fetchIntOrFloat: BBWarpBase+6 ofObject: bitBltOop.
	deltaP43x _ self deltaFrom: pBx to: words nSteps: nSteps.
	deltaP43x < 0 ifTrue: [pBx _ words - (nSteps*deltaP43x)].

	pBy _ self fetchIntOrFloat: BBWarpBase+10 ofObject: bitBltOop.
	words _ self fetchIntOrFloat: BBWarpBase+7 ofObject: bitBltOop.
	deltaP43y _ self deltaFrom: pBy to: words nSteps: nSteps.
	deltaP43y < 0 ifTrue: [pBy _ words - (nSteps*deltaP43y)].

	interpreterProxy failed ifTrue: [^ false].  "ie if non-integers above"
	interpreterProxy methodArgumentCount = 2
		ifTrue: [smoothingCount _ interpreterProxy stackIntegerValue: 1.
				sourceMapOop _ interpreterProxy stackValue: 0.
				sourceMapOop = interpreterProxy nilObject
				ifTrue: [sourcePixSize < 16 ifTrue:
					["color map is required to smooth non-RGB dest"
					^ interpreterProxy primitiveFail]]
				ifFalse: [(interpreterProxy slotSizeOf: sourceMapOop)
							< (1 << sourcePixSize) ifTrue:
					["sourceMap must be long enough for sourcePixSize"
					^ interpreterProxy primitiveFail].
					sourceMapOop _ self cCoerce: (interpreterProxy firstIndexableField: sourceMapOop) to:'int']]
		ifFalse: [smoothingCount _ 1.
				sourceMapOop _ interpreterProxy nilObject].
	nSteps _ width-1.  nSteps <= 0 ifTrue: [nSteps _ 1].
	startBits _ pixPerWord - (dx bitAnd: pixPerWord-1).
	endBits _ ((dx + bbW - 1) bitAnd: pixPerWord-1) + 1.
 	bbW < startBits ifTrue:[startBits _ bbW].

	destY < clipY ifTrue:[
		"Advance increments if there was clipping in y"
		pAx _ pAx + (clipY - destY * deltaP12x).
		pAy _ pAy + (clipY - destY * deltaP12y).
		pBx _ pBx + (clipY - destY * deltaP43x).
		pBy _ pBy + (clipY - destY * deltaP43y)].

	"Setup values for faster pixel fetching.
	Note: this should really go into a separate method
	since it only sets up globals so there is no need to
	have it in this method."

		"warpSrcShift = log2(sourcePixSize)"
		warpSrcShift _ 0.
		words _ sourcePixSize. "recycle temp"
		[words = 1] whileFalse:[
			warpSrcShift _ warpSrcShift + 1.
			words _ words >> 1].

		"warpSrcMask = mask for extracting one pixel from source word"
		warpSrcMask _ maskTable at: sourcePixSize.

		"warpAlignShift: Shift for aligning x position to word boundary"
		warpAlignShift _ 5 - warpSrcShift.

		"warpAlignMask: Mask for extracting the pixel position from an x position"
		warpAlignMask _ 1 << warpAlignShift - 1.

		"Setup the lookup table for source bit shifts"
		"warpBitShiftTable: given an sub-word x value what's the bit shift?"
		0 to: warpAlignMask do:[:i|
			warpBitShiftTable at: i put: 32 - ( i + 1 << warpSrcShift )].

	1 to: bbH do:
		[ :i | "here is the vertical loop..."
		xDelta _ self deltaFrom: pAx to: pBx nSteps: nSteps.
 		xDelta >= 0 ifTrue: [sx _ pAx] ifFalse: [sx _ pBx - (nSteps*xDelta)].
		yDelta _ self deltaFrom: pAy to: pBy nSteps: nSteps.
 		yDelta >= 0 ifTrue: [sy _ pAy] ifFalse: [sy _ pBy - (nSteps*yDelta)].

		dstBitShift _ 32 - ((dx bitAnd: pixPerWord - 1) + 1 * destPixSize).

		(destX < clipX) ifTrue:[
			"Advance increments if there was clipping in x"
			sx _ sx + (clipX - destX * xDelta).
			sy _ sy + (clipX - destX * yDelta).
		].

		noHalftone
			ifTrue: [halftoneWord _ AllOnes]
			ifFalse: [halftoneWord _ self halftoneAt: dy+i-1].
		destMask _ mask1.
		nPix _ startBits.
		"Here is the inner loop..."
		words _ nWords.
			["pick up word"
			smoothingCount = 1 ifTrue:["Faster if not smoothing"
				skewWord _ self warpPickSourcePixels: nPix
								xDeltah: xDelta yDeltah: yDelta
								xDeltav: deltaP12x yDeltav: deltaP12y.
			] ifFalse:["more difficult with smoothing"
				skewWord _ self warpPickSmoothPixels: nPix
						xDeltah: xDelta yDeltah: yDelta
						xDeltav: deltaP12x yDeltav: deltaP12y
						sourceMap: sourceMapOop
						smoothing: smoothingCount.
			].
			destMask = AllOnes ifTrue:["avoid read-modify-write"
				mergeWord _ self mergeFn: (skewWord bitAnd: halftoneWord)
								with: (self dstLongAt: destIndex).
				self dstLongAt: destIndex put: (destMask bitAnd: mergeWord).
			] ifFalse:[ "General version using dest masking"
				destWord _ self dstLongAt: destIndex.
				mergeWord _ self mergeFn: (skewWord bitAnd: halftoneWord)
								with: (destWord bitAnd: destMask).
				destWord _ (destMask bitAnd: mergeWord) bitOr:
								(destWord bitAnd: destMask bitInvert32).
				self dstLongAt: destIndex put: destWord.
			].
			destIndex _ destIndex + 4.
			words = 2 "e.g., is the next word the last word?"
				ifTrue:["set mask for last word in this row"
						destMask _ mask2.
						nPix _ endBits]
				ifFalse:["use fullword mask for inner loop"
						destMask _ AllOnes.
						nPix _ pixPerWord].
			(words _ words - 1) = 0] whileFalse.
		"--- end of inner loop ---"
		pAx _ pAx + deltaP12x.
		pAy _ pAy + deltaP12y.
		pBx _ pBx + deltaP43x.
		pBy _ pBy + deltaP43y.
		destIndex _ destIndex + destDelta]