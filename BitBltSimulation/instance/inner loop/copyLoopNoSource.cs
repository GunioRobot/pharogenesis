copyLoopNoSource
	| halftoneWord mergeWord mergeFnwith |
	"Faster copyLoop when source not used.  hDir and vDir are both
	positive, and perload and skew are unused"

	self inline: false.
	self var: #mergeFnwith declareC: 'int (*mergeFnwith)(int, int)'.
	mergeFnwith _ self cCoerce: (opTable at: combinationRule+1) to: 'int (*)(int, int)'.
	mergeFnwith.  "null ref for compiler"

	1 to: bbH do: "here is the vertical loop"
		[ :i |
		noHalftone
			ifTrue: [halftoneWord _ AllOnes]
			ifFalse: [halftoneWord _ interpreterProxy longAt: (halftoneBase + (dy+i-1 \\ halftoneHeight * 4))].

	"Note: the horizontal loop has been expanded into three parts for speed:"

			"This first section requires masking of the destination store..."
			mergeWord _ self mergeFn: halftoneWord
							with: (interpreterProxy longAt: destIndex).
			interpreterProxy longAt: destIndex
				put: ((mask1 bitAnd: mergeWord)
					bitOr: (mask1 bitInvert32 bitAnd: (interpreterProxy longAt: destIndex))).
			destIndex _ destIndex + 4.

		"This central horizontal loop requires no store masking"
combinationRule = 3
ifTrue: [2 to: nWords-1 do: "Special inner loop for STORE"
			[ :word |
			interpreterProxy longAt: destIndex put: halftoneWord.
			destIndex _ destIndex + 4].
] ifFalse: [2 to: nWords-1 do: "Normal inner loop does merge"
			[ :word |
			mergeWord _ self mergeFn: halftoneWord
							with: (interpreterProxy longAt: destIndex).
			interpreterProxy longAt: destIndex put: mergeWord.
			destIndex _ destIndex + 4].

].

		"This last section, if used, requires masking of the destination store..."
		nWords > 1 ifTrue:
			[mergeWord _ self mergeFn: halftoneWord
							with: (interpreterProxy longAt: destIndex).
			interpreterProxy longAt: destIndex
				put: ((mask2 bitAnd: mergeWord)
					bitOr: (mask2 bitInvert32 bitAnd: (interpreterProxy longAt: destIndex))).
			destIndex _ destIndex + 4].

	destIndex _ destIndex + destDelta]