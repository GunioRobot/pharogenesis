warpLoop
	"This version of the inner loop traverses an arbirary quadrilateral
	source, thus producing a general affine transformation."
	| skewWord halftoneWord mergeWord startBits
	deltaP12x deltaP12y deltaP43x deltaP43y pAx pAy pBx pBy
	xDelta yDelta nSteps nPix words destWord endBits 
	srcPaint mergeFn |
	"We want to inline this into the specialized versions"
	self inline: true.
	false ifTrue:[
	"Check if we have a simple scaling and can short cut this into scaleLoop"
	((warpQuad at: 0) "p1x" = (warpQuad at: 2) "p2x"
		and:[(warpQuad at: 4) "p3x" = (warpQuad at: 6) "p4x"
		and:[(warpQuad at: 1) "p1y" = (warpQuad at: 7) "p4y"
		and:[(warpQuad at: 3) "p2y" = (warpQuad at: 5) "p3y"]]])
			ifTrue:["^self scaleLoop"]].
	mergeFn _ opTable at: combinationRule+1.
	srcPaint _ srcKeyMode.

 	nSteps _ height-1.  nSteps <= 0 ifTrue: [nSteps _ 1].

	pAx _ warpQuad at: 0.	words _ warpQuad at: 2.
	deltaP12x _ self deltaFrom: pAx to: words nSteps: nSteps.
	deltaP12x < 0 ifTrue: [pAx _ words - (nSteps*deltaP12x)].

	pAy _ warpQuad at: 1.	words _ warpQuad at: 3.
	deltaP12y _ self deltaFrom: pAy to: words nSteps: nSteps.
	deltaP12y < 0 ifTrue: [pAy _ words - (nSteps*deltaP12y)].

	pBx _ warpQuad at: 6.	words _ warpQuad at: 4.
	deltaP43x _ self deltaFrom: pBx to: words nSteps: nSteps.
	deltaP43x < 0 ifTrue: [pBx _ words - (nSteps*deltaP43x)].

	pBy _ warpQuad at: 7.	words _ warpQuad at: 5.
	deltaP43y _ self deltaFrom: pBy to: words nSteps: nSteps.
	deltaP43y < 0 ifTrue: [pBy _ words - (nSteps*deltaP43y)].

	nSteps _ width-1.  nSteps <= 0 ifTrue: [nSteps _ 1].
	startBits _ destPPW - (dx bitAnd: destPPW-1).
	endBits _ ((dx + bbW - 1) bitAnd: destPPW-1) + 1.
 	bbW < startBits ifTrue:[startBits _ bbW].

	destY < clipY ifTrue:[
		"Advance increments if there was clipping in y"
		pAx _ pAx + (clipY - destY * deltaP12x).
		pAy _ pAy + (clipY - destY * deltaP12y).
		pBx _ pBx + (clipY - destY * deltaP43x).
		pBy _ pBy + (clipY - destY * deltaP43y)].

	"Setup values for faster pixel fetching."
	self warpSetup.

	1 to: bbH do:
		[ :i | "here is the vertical loop..."
		xDelta _ self deltaFrom: pAx to: pBx nSteps: nSteps.
 		xDelta >= 0 ifTrue: [sx _ pAx] ifFalse: [sx _ pBx - (nSteps*xDelta)].
		yDelta _ self deltaFrom: pAy to: pBy nSteps: nSteps.
 		yDelta >= 0 ifTrue: [sy _ pAy] ifFalse: [sy _ pBy - (nSteps*yDelta)].

		destMSB
			ifTrue:[dstBitShift _ 32 - ((dx bitAnd: destPPW - 1) + 1 * destDepth)]
			ifFalse:[dstBitShift _ (dx bitAnd: destPPW - 1) * destDepth].
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
			destWord _ self dstLongAt: destIndex.
			warpQuality = 1 ifTrue:["Faster if not smoothing"
				skewWord _ self warpPickSourcePixels: nPix
								xDeltah: xDelta yDeltah: yDelta
								xDeltav: deltaP12x yDeltav: deltaP12y
								paintMode: srcPaint destWord: destWord
			] ifFalse:["more difficult with smoothing"
				skewWord _ self warpPickSmoothPixels: nPix
						xDeltah: xDelta yDeltah: yDelta
						xDeltav: deltaP12x yDeltav: deltaP12y
						paintMode: srcPaint destWord: destWord.
			].
			mergeWord _ self merge: (skewWord bitAnd: halftoneWord)
							with: (destWord bitAnd: destMask)
							function: mergeFn.
			destWord _ (destMask bitAnd: mergeWord) bitOr:
							(destWord bitAnd: destMask bitInvert32).
			self dstLongAt: destIndex put: destWord.
			destIndex _ destIndex + 4.
			words = 2 "e.g., is the next word the last word?"
				ifTrue:["set mask for last word in this row"
						destMask _ mask2.
						nPix _ endBits]
				ifFalse:["use fullword mask for inner loop"
						destMask _ AllOnes.
						nPix _ destPPW].
			(words _ words - 1) = 0] whileFalse.
		"--- end of inner loop ---"
		pAx _ pAx + deltaP12x.
		pAy _ pAy + deltaP12y.
		pBx _ pBx + deltaP43x.
		pBy _ pBy + deltaP43y.
		destIndex _ destIndex + destDelta]