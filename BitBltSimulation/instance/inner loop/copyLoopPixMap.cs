copyLoopPixMap
	"This version of the inner loop maps source pixels
	to a destination form with different depth.  Because it is already
	unweildy, the loop is not unrolled as in the other versions.
	Preload, skew and skewMask are all overlooked, since pickSourcePixels
	delivers its destination word already properly aligned.
	Note that pickSourcePixels could be copied in-line at the top of
	the horizontal loop, and some of its inits moved out of the loop."

	| skewWord halftoneWord mergeWord destMask srcPixPerWord scrStartBits nSourceIncs startBits endBits sourcePixMask destPixMask nullMap mergeFnwith |

	self inline: false.
	self var: #mergeFnwith declareC: 'int (*mergeFnwith)(int, int)'.
	mergeFnwith _ self cCoerce: (opTable at: combinationRule+1) to: 'int (*)(int, int)'.
	mergeFnwith.  "null ref for compiler"

	"Additional inits peculiar to unequal source and dest pix size..."
	srcPixPerWord _ 32//sourcePixSize.
	"Check for degenerate shift values 4/28/97 ar"
	sourcePixSize = 32 
		ifTrue: [ sourcePixMask _ -1]
		ifFalse: [ sourcePixMask _ (1 << sourcePixSize) - 1].
	destPixSize = 32
		ifTrue: [ destPixMask _ -1]
		ifFalse: [ destPixMask _ (1 << destPixSize) - 1].
	nullMap _ colorMap = interpreterProxy nilObject.
	sourceIndex _ (sourceBits + 4) +
					(sy * sourceRaster + (sx // srcPixPerWord) *4).
	scrStartBits _ srcPixPerWord - (sx bitAnd: srcPixPerWord-1).
	bbW < scrStartBits
		ifTrue: [nSourceIncs _ 0]
		ifFalse: [nSourceIncs _ (bbW - scrStartBits)//srcPixPerWord + 1].
	sourceDelta _ (sourceRaster - nSourceIncs) * 4.

	"Note following two items were already calculated in destmask setup!"
	startBits _ pixPerWord - (dx bitAnd: pixPerWord-1).
	endBits _ ((dx + bbW - 1) bitAnd: pixPerWord-1) + 1.

	1 to: bbH do: "here is the vertical loop"
		[ :i |
		noHalftone
			ifTrue: [halftoneWord _ AllOnes]
			ifFalse: [halftoneWord _ interpreterProxy longAt: (halftoneBase + (dy+i-1 \\ halftoneHeight * 4))].
		srcBitIndex _ (sx bitAnd: srcPixPerWord - 1)*sourcePixSize.
		destMask _ mask1.
		"pick up first word"
		bbW < startBits
			ifTrue: [skewWord _ self pickSourcePixels: bbW nullMap: nullMap
									srcMask: sourcePixMask destMask: destPixMask.
					skewWord _ skewWord   "See note below"
							bitShift: (startBits - bbW)*destPixSize]
			ifFalse: [skewWord _ self pickSourcePixels: startBits nullMap: nullMap
									srcMask: sourcePixMask destMask: destPixMask]. 

		"Here is the horizontal loop..."
		1 to: nWords do: "here is the inner horizontal loop"
			[ :word |
			mergeWord _ self mergeFn: (skewWord bitAnd: halftoneWord)
							with: ((interpreterProxy longAt: destIndex) bitAnd: destMask).
			interpreterProxy longAt: destIndex
				put: ((destMask bitAnd: mergeWord)
					bitOr:
					(destMask bitInvert32 bitAnd: (interpreterProxy longAt: destIndex))).
			destIndex _ destIndex + 4.
			word >= (nWords - 1) ifTrue:
				[word = nWords ifFalse:
					["set mask for last word in this row"
					destMask _ mask2.
					skewWord _ self pickSourcePixels: endBits nullMap: nullMap
									srcMask: sourcePixMask destMask: destPixMask.
					skewWord _ skewWord   "See note below"
							bitShift: (pixPerWord-endBits)*destPixSize]]
				ifFalse: 
				["use fullword mask for inner loop"
				destMask _ AllOnes.
				skewWord _ self pickSourcePixels: pixPerWord nullMap: nullMap srcMask: sourcePixMask destMask: destPixMask]].

	sourceIndex _ sourceIndex + sourceDelta.
	destIndex _ destIndex + destDelta]

"NOTE: in both noted shifts above, we are shifting the right-justified
 output of pickSourcePixels so that it is aligned with the destination word.
  Since it gets masked anyway, we could have just picked more pixels
 (startBits in the first case and destPixSize in the second), and it would
 have been simpler, but it is slower to run the pickSourcePixels loop. 
 CopyLoopAlphaHack takes advantage of this to avoid having to shift
 full-words in its alphaSource buffer" 