copyLoopPixMap
	"This version of the inner loop maps source pixels
	to a destination form with different depth.
	Note: Special care is taken to handle source paint mode correctly."
	| skewWord halftoneWord mergeWord scrStartBits nSourceIncs startBits endBits 
	sourcePixMask destPixMask nPix srcShift dstShift destWord 
	words srcPaint mergeFn |
	"Note: This method is inlined for specialization of LSB-MSB conversion"
	self inline: true.
	mergeFn _ opTable at: combinationRule+1.
	srcPaint _ srcKeyMode.

	"Additional inits peculiar to unequal source and dest pix size..."
	sourcePixMask _ maskTable at: sourceDepth.
	destPixMask _ maskTable at: destDepth.
	sourceIndex _ sourceBits + (sy * sourcePitch) + ((sx // sourcePPW) *4).
	scrStartBits _ sourcePPW - (sx bitAnd: sourcePPW-1).
	bbW < scrStartBits
		ifTrue: [nSourceIncs _ 0]
		ifFalse: [nSourceIncs _ (bbW - scrStartBits)//sourcePPW + 1].
	sourceDelta _ sourcePitch - (nSourceIncs * 4).

	"Note following two items were already calculated in destmask setup!"
	startBits _ destPPW - (dx bitAnd: destPPW-1).
	endBits _ ((dx + bbW - 1) bitAnd: destPPW-1) + 1.

	bbW < startBits ifTrue:[startBits _ bbW].

	"Precomputed shifts for pickSourcePixels"
	srcShift _ ((sx bitAnd: sourcePPW - 1) * sourceDepth).
	dstShift _ ((dx bitAnd: destPPW - 1) * destDepth).
	sourceMSB ifTrue:[srcShift _ 32 - sourceDepth - srcShift].
	destMSB ifTrue:[dstShift _ 32 - destDepth - dstShift].

	1 to: bbH do: "here is the vertical loop"
		[ :i |
		noHalftone
			ifTrue:[halftoneWord _ AllOnes]
			ifFalse: [halftoneWord _ self halftoneAt: dy+i-1].
		"setup first load"
		srcBitShift _ srcShift.
		dstBitShift _ dstShift.
		destMask _ mask1.
		nPix _ startBits.
		"Here is the horizontal loop..."
		words _ nWords.
			["pick up the word"
			destWord _ self dstLongAt: destIndex.
			skewWord _ self pickSourcePixels: nPix
							srcMask: sourcePixMask 
							destMask: destPixMask
							paintMode: srcPaint
							destWord: destWord.
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
		sourceIndex _ sourceIndex + sourceDelta.
		destIndex _ destIndex + destDelta]

