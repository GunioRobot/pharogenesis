pixSwap: sourceWord with: destWord
	"Swap the pixels in destWord"
	| result shift lowMask highMask |
	self inline: false.
	destPPW = 1 ifTrue:[^destWord]. "a single pixel per word"
	result _ 0.
	lowMask _ (1 << destDepth) - 1. "mask low pixel"
	highMask _ lowMask << (destPPW-1 * destDepth). "mask high pixel"
	shift _ 32 - destDepth.
	result _ result bitOr: (
				(destWord bitAnd: lowMask) << shift bitOr:
					(destWord bitAnd: highMask) >> shift).
	destPPW <= 2 ifTrue:[^result].
	2 to: destPPW // 2 do:[:i|
		lowMask _ lowMask << destDepth.
		highMask _ highMask >> destDepth.
		shift _ shift - (destDepth * 2).
		result _ result bitOr: (
					(destWord bitAnd: lowMask) << shift bitOr:
						(destWord bitAnd: highMask) >> shift)].
	^result