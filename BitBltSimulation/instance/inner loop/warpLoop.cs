warpLoop
	"ar 12/7/1999: This version is unused but kept as reference implemenation"
	"This version of the inner loop traverses an arbirary quadrilateral
	source, thus producing a general affine transformation."
	| skewWord halftoneWord mergeWord startBits
	  deltaP12x deltaP12y deltaP43x deltaP43y pAx pAy
	  xDelta yDelta pBx pBy smoothingCount sourceMapOop nSteps t |
	self inline: false.
 
	(interpreterProxy slotSizeOf: bitBltOop) >= (BBWarpBase+12)
		ifFalse: [^ interpreterProxy primitiveFail].
	nSteps _ height-1.  nSteps <= 0 ifTrue: [nSteps _ 1].

	pAx _ self fetchIntOrFloat: BBWarpBase ofObject: bitBltOop.
	t _ self fetchIntOrFloat: BBWarpBase+3 ofObject: bitBltOop.
	deltaP12x _ self deltaFrom: pAx to: t nSteps: nSteps.
	deltaP12x < 0 ifTrue: [pAx _ t - (nSteps*deltaP12x)].

	pAy _ self fetchIntOrFloat: BBWarpBase+1 ofObject: bitBltOop.
	t _ self fetchIntOrFloat: BBWarpBase+4 ofObject: bitBltOop.
	deltaP12y _ self deltaFrom: pAy to: t nSteps: nSteps.
	deltaP12y < 0 ifTrue: [pAy _ t - (nSteps*deltaP12y)].

	pBx _ self fetchIntOrFloat: BBWarpBase+9 ofObject: bitBltOop.
	t _ self fetchIntOrFloat: BBWarpBase+6 ofObject: bitBltOop.
	deltaP43x _ self deltaFrom: pBx to: t nSteps: nSteps.
	deltaP43x < 0 ifTrue: [pBx _ t - (nSteps*deltaP43x)].

	pBy _ self fetchIntOrFloat: BBWarpBase+10 ofObject: bitBltOop.
	t _ self fetchIntOrFloat: BBWarpBase+7 ofObject: bitBltOop.
	deltaP43y _ self deltaFrom: pBy to: t nSteps: nSteps.
	deltaP43y < 0 ifTrue: [pBy _ t - (nSteps*deltaP43y)].

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
					^ interpreterProxy primitiveFail]]]
		ifFalse: [smoothingCount _ 1.
				sourceMapOop _ interpreterProxy nilObject].
	startBits _ pixPerWord - (dx bitAnd: pixPerWord-1).
	nSteps _ width-1.  nSteps <= 0 ifTrue: [nSteps _ 1].
 
	destY to: clipY-1 do:
		[ :i |	"Advance increments if there was clipping in y"
		pAx _ pAx + deltaP12x.
		pAy _ pAy + deltaP12y.
		pBx _ pBx + deltaP43x.
		pBy _ pBy + deltaP43y].

	1 to: bbH do:
		[ :i |		"here is the vertical loop..."
		xDelta _ self deltaFrom: pAx to: pBx nSteps: nSteps.
 		xDelta >= 0 ifTrue: [sx _ pAx] ifFalse: [sx _ pBx - (nSteps*xDelta)].
		yDelta _ self deltaFrom: pAy to: pBy nSteps: nSteps.
 		yDelta >= 0 ifTrue: [sy _ pAy] ifFalse: [sy _ pBy - (nSteps*yDelta)].

		destX to: clipX-1 do:
			[:word |	"Advance increments if there was clipping in x"
			sx _ sx + xDelta.
			sy _ sy + yDelta].

		noHalftone
			ifTrue: [halftoneWord _ AllOnes]
			ifFalse: [halftoneWord _ self halftoneAt: dy+i-1].
		destMask _ mask1.
		"pick up first word"
		bbW < startBits
			ifTrue: [skewWord _ self warpSourcePixels: bbW
									xDeltah: xDelta yDeltah: yDelta
									xDeltav: deltaP12x yDeltav: deltaP12y
									smoothing: smoothingCount sourceMap: sourceMapOop.
					skewWord _ skewWord
							bitShift: (startBits - bbW)*destPixSize]
			ifFalse: [skewWord _ self warpSourcePixels: startBits
									xDeltah: xDelta yDeltah: yDelta
									xDeltav: deltaP12x yDeltav: deltaP12y
									smoothing: smoothingCount sourceMap: sourceMapOop].
 
		1 to: nWords do:
			[ :word |		"here is the inner horizontal loop..."
			mergeWord _ self merge: (skewWord bitAnd: halftoneWord)
				with: ((self dstLongAt: destIndex) bitAnd: destMask).
			self dstLongAt: destIndex put: (destMask bitAnd: mergeWord)
				mask: destMask bitInvert32.
			destIndex _ destIndex + 4.
			word >= (nWords - 1) ifTrue:
				[word = nWords ifFalse:
					["set mask for last word in this row"
					destMask _ mask2.
					skewWord _ self warpSourcePixels: pixPerWord
									xDeltah: xDelta yDeltah: yDelta
									xDeltav: deltaP12x yDeltav: deltaP12y
									smoothing: smoothingCount sourceMap: sourceMapOop]]
				ifFalse:
				["use fullword mask for inner loop"
				destMask _ AllOnes.
				skewWord _ self warpSourcePixels: pixPerWord
									xDeltah: xDelta yDeltah: yDelta
									xDeltav: deltaP12x yDeltav: deltaP12y
									smoothing: smoothingCount sourceMap: sourceMapOop].
			].
		pAx _ pAx + deltaP12x.
		pAy _ pAy + deltaP12y.
		pBx _ pBx + deltaP43x.
		pBy _ pBy + deltaP43y.
		destIndex _ destIndex + destDelta]