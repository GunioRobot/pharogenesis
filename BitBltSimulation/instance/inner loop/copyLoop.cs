copyLoop
	"This version of the inner loop assumes noSource = false."
	| prevWord thisWord skewWord halftoneWord mergeWord hInc y unskew skewMask notSkewMask mergeFnwith destWord skewLocal sourceIndexLocal destIndexLocal vDirLocal hDirLocal nWordsMinusOne |
	self inline: false.
	self var: #mergeFnwith declareC: 'int (*mergeFnwith)(int, int)'.
	mergeFnwith _ self
				cCoerce: (opTable at: combinationRule + 1)
				to: 'int (*)(int, int)'.
	mergeFnwith.
	"null ref for compiler"
	hInc _ hDir * 4.
	skewLocal _ skew.
	sourceIndexLocal _ sourceIndex.
	destIndexLocal _ destIndex.
	vDirLocal _ vDir.
	hDirLocal _ hDir.
	nWordsMinusOne _ nWords - 1.
	"Byte delta"
	"degenerate skew fixed for Sparc. 10/20/96 ikp"
	skewLocal == -32
		ifTrue: [skewLocal _ unskew _ skewMask _ 0]
		ifFalse: [skewLocal < 0
				ifTrue: [unskew _ skewLocal + 32.
					skewMask _ AllOnes << (0 - skewLocal)]
				ifFalse: [skewLocal = 0
						ifTrue: [unskew _ 0.
							skewMask _ AllOnes]
						ifFalse: [unskew _ skewLocal - 32.
							skewMask _ AllOnes >> skewLocal]]].
	notSkewMask _ skewMask bitInvert32.
	noHalftone
		ifTrue: [halftoneWord _ AllOnes.
			halftoneHeight _ 0]
		ifFalse: [halftoneWord _ self halftoneAt: 0].
	y _ dy.
	1
		to: bbH
		do: [:i | 
			"here is the vertical loop"
			halftoneHeight > 1
				ifTrue: ["Otherwise, its always the same"
					halftoneWord _ self halftoneAt: y.
					y _ y + vDirLocal].
			preload
				ifTrue: ["load the 64-bit shifter"
					prevWord _ self srcLongAt: sourceIndexLocal.
					sourceIndexLocal _ sourceIndexLocal + hInc]
				ifFalse: [prevWord _ 0].
			"Note: the horizontal loop has been expanded into three parts for 
			speed:"
			"This first section requires masking of the destination store..."
			destMask _ mask1.
			thisWord _ self srcLongAt: sourceIndexLocal.
			"pick up next word"
			sourceIndexLocal _ sourceIndexLocal + hInc.
			skewWord _ ((prevWord bitAnd: notSkewMask)
						bitShift: unskew)
						bitOr: ((thisWord bitAnd: skewMask)
								bitShift: skewLocal).
			"32-bit rotate"
			prevWord _ thisWord.
			destWord _ self dstLongAt: destIndexLocal.
			mergeWord _ self
						mergeFn: (skewWord bitAnd: halftoneWord)
						with: destWord.
			destWord _ (destMask bitAnd: mergeWord)
						bitOr: (destWord bitAnd: destMask bitInvert32).
			self dstLongAt: destIndexLocal put: destWord.
			destIndexLocal _ destIndexLocal + hInc.
			"This central horizontal loop requires no store masking"
			destMask _ AllOnes.
			combinationRule = 3
				ifTrue: [skewLocal = 0 & (halftoneWord = AllOnes)
						ifTrue: ["Very special inner loop for STORE mode with no 
							skew -- just move words"
							hDirLocal = -1
								ifTrue: ["Woeful patch: revert to older code for  
									hDir = -1"
									2
										to: nWordsMinusOne
										do: [:word | 
											thisWord _ self srcLongAt: sourceIndexLocal.
											sourceIndexLocal _ sourceIndexLocal + hInc.
											self dstLongAt: destIndexLocal put: thisWord.
											destIndexLocal _ destIndexLocal + hInc]]
								ifFalse: [2
										to: nWordsMinusOne
										do: [:word | 
											"Note loop starts with prevWord  
											loaded (due to preload)"
											self dstLongAt: destIndexLocal put: prevWord.
											destIndexLocal _ destIndexLocal + hInc.
											prevWord _ self srcLongAt: sourceIndexLocal.
											sourceIndexLocal _ sourceIndexLocal + hInc]]]
						ifFalse: ["Special inner loop for STORE mode -- no need to 
							call merge"
							2
								to: nWordsMinusOne
								do: [:word | 
									thisWord _ self srcLongAt: sourceIndexLocal.
									sourceIndexLocal _ sourceIndexLocal + hInc.
									skewWord _ ((prevWord bitAnd: notSkewMask)
												bitShift: unskew)
												bitOr: ((thisWord bitAnd: skewMask)
														bitShift: skewLocal).
									"32-bit rotate"
									prevWord _ thisWord.
									self
										dstLongAt: destIndexLocal
										put: (skewWord bitAnd: halftoneWord).
									destIndexLocal _ destIndexLocal + hInc]]]
				ifFalse: [2
						to: nWordsMinusOne
						do: [:word | 
							"Normal inner loop does merge:"
							thisWord _ self srcLongAt: sourceIndexLocal.
							"pick up next word"
							sourceIndexLocal _ sourceIndexLocal + hInc.
							skewWord _ ((prevWord bitAnd: notSkewMask)
										bitShift: unskew)
										bitOr: ((thisWord bitAnd: skewMask)
												bitShift: skewLocal).
							"32-bit rotate"
							prevWord _ thisWord.
							mergeWord _ self
										mergeFn: (skewWord bitAnd: halftoneWord)
										with: (self dstLongAt: destIndexLocal).
							self dstLongAt: destIndexLocal put: mergeWord.
							destIndexLocal _ destIndexLocal + hInc]].
			"This last section, if used, requires masking of the destination  
			store..."
			nWords > 1
				ifTrue: [destMask _ mask2.
					thisWord _ self srcLongAt: sourceIndexLocal.
					"pick up next word"
					sourceIndexLocal _ sourceIndexLocal + hInc.
					skewWord _ ((prevWord bitAnd: notSkewMask)
								bitShift: unskew)
								bitOr: ((thisWord bitAnd: skewMask)
										bitShift: skewLocal).
					"32-bit rotate"
					destWord _ self dstLongAt: destIndexLocal.
					mergeWord _ self
								mergeFn: (skewWord bitAnd: halftoneWord)
								with: destWord.
					destWord _ (destMask bitAnd: mergeWord)
								bitOr: (destWord bitAnd: destMask bitInvert32).
					self dstLongAt: destIndexLocal put: destWord.
					destIndexLocal _ destIndexLocal + hInc].
			sourceIndexLocal _ sourceIndexLocal + sourceDelta.
			destIndexLocal _ destIndexLocal + destDelta]