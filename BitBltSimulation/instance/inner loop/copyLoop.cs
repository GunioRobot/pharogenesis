copyLoop
	| prevWord thisWord skewWord halftoneWord mergeWord hInc y unskew skewMask notSkewMask mergeFnwith |
	"This version of the inner loop assumes noSource = false."
	self inline: false.
	self var: #mergeFnwith declareC: 'int (*mergeFnwith)(int, int)'.
	mergeFnwith _ self cCoerce: (opTable at: combinationRule+1) to: 'int (*)(int, int)'.
	mergeFnwith.  "null ref for compiler"

	hInc _ hDir*4.  "Byte delta"
	"degenerate skew fixed for Sparc. 10/20/96 ikp"
	skew == -32
		ifTrue: [skew _ unskew _ skewMask _ 0]
		ifFalse: [skew < 0
			ifTrue:
				[unskew _ skew+32.
				skewMask _ AllOnes << (0-skew)]
			ifFalse:
				[skew == 0
					ifTrue:
						[unskew _ 0.
						skewMask _ AllOnes]
					ifFalse:
						[unskew _ skew-32.
						skewMask _ AllOnes >> skew]]].
	notSkewMask _ skewMask bitInvert32.
	noHalftone
		ifTrue: [halftoneWord _ AllOnes.  halftoneHeight _ 0]
		ifFalse: [halftoneWord _ interpreterProxy longAt: halftoneBase].
	y _ dy.
	1 to: bbH do: "here is the vertical loop"
		[ :i |
		halftoneHeight > 1 ifTrue:  "Otherwise, its always the same"
			[halftoneWord _ interpreterProxy longAt:
						(halftoneBase + (y \\ halftoneHeight * 4)).
			y _ y + vDir].
		preload ifTrue:
			["load the 64-bit shifter"
			prevWord _ interpreterProxy longAt: sourceIndex.
			sourceIndex _ sourceIndex + hInc]
			ifFalse:
			[prevWord _ 0].

	"Note: the horizontal loop has been expanded into three parts for speed:"

			"This first section requires masking of the destination store..."
			thisWord _ interpreterProxy longAt: sourceIndex.  "pick up next word"
			skewWord _ ((prevWord bitAnd: notSkewMask) bitShift: unskew)
							bitOr:  "32-bit rotate"
						((thisWord bitAnd: skewMask) bitShift: skew).
			prevWord _ thisWord.
			sourceIndex _ sourceIndex + hInc.
			mergeWord _ self mergeFn: (skewWord bitAnd: halftoneWord)
							with: (interpreterProxy longAt: destIndex).
			interpreterProxy longAt: destIndex
				put: ((mask1 bitAnd: mergeWord)
					bitOr: (mask1 bitInvert32 bitAnd: (interpreterProxy longAt: destIndex))).
			destIndex _ destIndex + hInc.

		"This central horizontal loop requires no store masking"
combinationRule = 3
ifTrue: [2 to: nWords-1 do: "Special inner loop for STORE"
			[ :word |
			thisWord _ interpreterProxy longAt: sourceIndex.  "pick up next word"
			skewWord _ ((prevWord bitAnd: notSkewMask) bitShift: unskew)
							bitOr:  "32-bit rotate"
						((thisWord bitAnd: skewMask) bitShift: skew).
			prevWord _ thisWord.
			sourceIndex _ sourceIndex + hInc.
			interpreterProxy longAt: destIndex put: (skewWord bitAnd: halftoneWord).
			destIndex _ destIndex + hInc]
] ifFalse: [2 to: nWords-1 do: "Normal inner loop does merge:"
			[ :word |
			thisWord _ interpreterProxy longAt: sourceIndex.  "pick up next word"
			skewWord _ ((prevWord bitAnd: notSkewMask) bitShift: unskew)
							bitOr:  "32-bit rotate"
						((thisWord bitAnd: skewMask) bitShift: skew).
			prevWord _ thisWord.
			sourceIndex _ sourceIndex + hInc.
			mergeWord _ self mergeFn: (skewWord bitAnd: halftoneWord)
							with: (interpreterProxy longAt: destIndex).
			interpreterProxy longAt: destIndex put: mergeWord.
			destIndex _ destIndex + hInc]
].

		"This last section, if used, requires masking of the destination store..."
		nWords > 1 ifTrue:
			[thisWord _ interpreterProxy longAt: sourceIndex.  "pick up next word"
			skewWord _ ((prevWord bitAnd: notSkewMask) bitShift: unskew)
							bitOr:  "32-bit rotate"
						((thisWord bitAnd: skewMask) bitShift: skew).
			prevWord _ thisWord.
			sourceIndex _ sourceIndex + hInc.
			mergeWord _ self mergeFn: (skewWord bitAnd: halftoneWord)
							with: (interpreterProxy longAt: destIndex).
			interpreterProxy longAt: destIndex
				put: ((mask2 bitAnd: mergeWord)
					bitOr: (mask2 bitInvert32 bitAnd: (interpreterProxy longAt: destIndex))).
			destIndex _ destIndex + hInc].

	sourceIndex _ sourceIndex + sourceDelta.
	destIndex _ destIndex + destDelta]