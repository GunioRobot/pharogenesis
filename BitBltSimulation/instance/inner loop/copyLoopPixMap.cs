copyLoopPixMap
	"This version of the inner loop maps source pixels  
	to a destination form with different depth. Because it is already  
	unweildy, the loop is not unrolled as in the other versions.  
	Preload, skew and skewMask are all overlooked, since pickSourcePixels  
	delivers its destination word already properly aligned.  
	Note that pickSourcePixels could be copied in-line at the top of  
	the horizontal loop, and some of its inits moved out of the loop."
	"ar 12/7/1999:  
	The loop has been rewritten to use only one pickSourcePixels call.  
	The idea is that the call itself could be inlined. If we decide not  
	to inline pickSourcePixels we could optimize the loop instead."
	| skewWord halftoneWord mergeWord scrStartBits nSourceIncs startBits endBits sourcePixMask destPixMask mergeFnwith nPix srcShift dstShift destWord words srcShiftInc dstShiftInc dstShiftLeft mapperFlags destIndexLocal |
	self inline: false.
	self var: #mergeFnwith declareC: 'int (*mergeFnwith)(int, int)'.
	mergeFnwith _ self
				cCoerce: (opTable at: combinationRule + 1)
				to: 'int (*)(int, int)'.
	mergeFnwith.
	"null ref for compiler"
	destIndexLocal _ destIndex.
	"Additional inits peculiar to unequal source and dest pix size..."
	sourcePPW _ 32 // sourceDepth.
	sourcePixMask _ maskTable at: sourceDepth.
	destPixMask _ maskTable at: destDepth.
	mapperFlags _ cmFlags bitAnd: ColorMapNewStyle bitInvert32.
	sourceIndex _ sourceBits + (sy * sourcePitch) + (sx // sourcePPW * 4).
	scrStartBits _ sourcePPW
				- (sx bitAnd: sourcePPW - 1).
	bbW < scrStartBits
		ifTrue: [nSourceIncs _ 0]
		ifFalse: [nSourceIncs _ bbW - scrStartBits // sourcePPW + 1].
	sourceDelta _ sourcePitch - (nSourceIncs * 4).
	"Note following two items were already calculated in destmask setup!"
	startBits _ destPPW
				- (dx bitAnd: destPPW - 1).
	endBits _ (dx + bbW - 1 bitAnd: destPPW - 1)
				+ 1.
	bbW < startBits
		ifTrue: [startBits _ bbW].
	"Precomputed shifts for pickSourcePixels"
	srcShift _ (sx bitAnd: sourcePPW - 1)
				* sourceDepth.
	dstShift _ (dx bitAnd: destPPW - 1)
				* destDepth.
	srcShiftInc _ sourceDepth.
	dstShiftInc _ destDepth.
	dstShiftLeft _ 0.
	sourceMSB
		ifTrue: [srcShift _ 32 - sourceDepth - srcShift.
			srcShiftInc _ 0 - srcShiftInc].
	destMSB
		ifTrue: [dstShift _ 32 - destDepth - dstShift.
			dstShiftInc _ 0 - dstShiftInc.
			dstShiftLeft _ 32 - destDepth].
	1
		to: bbH
		do: [:i | 
			"here is the vertical loop"
			"*** is it possible at all that noHalftone == false? ***"
			noHalftone
				ifTrue: [halftoneWord _ AllOnes]
				ifFalse: [halftoneWord _ self halftoneAt: dy + i - 1].
			"setup first load"
			srcBitShift _ srcShift.
			dstBitShift _ dstShift.
			destMask _ mask1.
			nPix _ startBits.
			"Here is the horizontal loop..."
			words _ nWords.
			["pick up the word"
			skewWord _ self
						pickSourcePixels: nPix
						flags: mapperFlags
						srcMask: sourcePixMask
						destMask: destPixMask
						srcShiftInc: srcShiftInc
						dstShiftInc: dstShiftInc.
			"align next word to leftmost pixel"
			dstBitShift _ dstShiftLeft.
			destMask = AllOnes
				ifTrue: ["avoid read-modify-write"
					mergeWord _ self
								mergeFn: (skewWord bitAnd: halftoneWord)
								with: (self dstLongAt: destIndexLocal).
					self
						dstLongAt: destIndexLocal
						put: (destMask bitAnd: mergeWord)]
				ifFalse: ["General version using dest masking"
					destWord _ self dstLongAt: destIndexLocal.
					mergeWord _ self
								mergeFn: (skewWord bitAnd: halftoneWord)
								with: (destWord bitAnd: destMask).
					destWord _ (destMask bitAnd: mergeWord)
								bitOr: (destWord bitAnd: destMask bitInvert32).
					self dstLongAt: destIndexLocal put: destWord].
			destIndexLocal _ destIndexLocal + 4.
			words = 2
				ifTrue: ["e.g., is the next word the last word?"
					"set mask for last word in this row"
					destMask _ mask2.
					nPix _ endBits]
				ifFalse: ["use fullword mask for inner loop"
					destMask _ AllOnes.
					nPix _ destPPW].
			(words _ words - 1) = 0] whileFalse.
			"--- end of inner loop ---"
			sourceIndex _ sourceIndex + sourceDelta.
			destIndexLocal _ destIndexLocal + destDelta]