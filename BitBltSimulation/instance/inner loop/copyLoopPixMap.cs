copyLoopPixMap
	"This version of the inner loop maps source pixels
	to a destination form with different depth.  Because it is already
	unweildy, the loop is not unrolled as in the other versions.
	Preload, skew and skewMask are all overlooked, since pickSourcePixels
	delivers its destination word already properly aligned.
	Note that pickSourcePixels could be copied in-line at the top of
	the horizontal loop, and some of its inits moved out of the loop."
	"ar 12/7/1999:
	The loop has been rewritten to use only one pickSourcePixels call.
	The idea is that the call itself could be inlined. If we decide not
	to inline pickSourcePixels we could optimize the loop instead."
	| skewWord halftoneWord mergeWord srcPixPerWord scrStartBits nSourceIncs startBits endBits sourcePixMask destPixMask nullMap mergeFnwith nPix srcShift dstShift destWord words |
	self inline: false.
	self var: #mergeFnwith declareC: 'int (*mergeFnwith)(int, int)'.
	mergeFnwith _ self cCoerce: (opTable at: combinationRule+1) to: 'int (*)(int, int)'.
	mergeFnwith.  "null ref for compiler"

	"Additional inits peculiar to unequal source and dest pix size..."
	srcPixPerWord _ 32//sourcePixSize.
	sourcePixMask _ maskTable at: sourcePixSize.
	destPixMask _ maskTable at: destPixSize.
	nullMap _ colorMap = nil.
	sourceIndex _ sourceBits +
					(sy * sourcePitch) + ((sx // srcPixPerWord) *4).
	scrStartBits _ srcPixPerWord - (sx bitAnd: srcPixPerWord-1).
	bbW < scrStartBits
		ifTrue: [nSourceIncs _ 0]
		ifFalse: [nSourceIncs _ (bbW - scrStartBits)//srcPixPerWord + 1].
	sourceDelta _ sourcePitch - (nSourceIncs * 4).

	"Note following two items were already calculated in destmask setup!"
	startBits _ pixPerWord - (dx bitAnd: pixPerWord-1).
	endBits _ ((dx + bbW - 1) bitAnd: pixPerWord-1) + 1.

	bbW < startBits ifTrue:[startBits _ bbW].

	"Precomputed shifts for pickSourcePixels"
	srcShift _ 32 - ((sx bitAnd: srcPixPerWord - 1) + 1 * sourcePixSize).
	dstShift _ 32 - ((dx bitAnd: pixPerWord - 1) + 1 * destPixSize).

	1 to: bbH do: "here is the vertical loop"
		[ :i |
		"*** is it possible at all that noHalftone == false? ***"
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
			skewWord _ self pickSourcePixels: nPix nullMap: nullMap 
								srcMask: sourcePixMask destMask: destPixMask.

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
		sourceIndex _ sourceIndex + sourceDelta.
		destIndex _ destIndex + destDelta]
