colorConvertMCU
	| y cb cr red green blue |
	yComponent at: CurrentXIndex put: 0.
	yComponent at: CurrentYIndex put: 0.
	cbComponent at: CurrentXIndex put: 0.
	cbComponent at: CurrentYIndex put: 0.
	crComponent at: CurrentXIndex put: 0.
	crComponent at: CurrentYIndex put: 0.
	0 to: jpegBitsSize-1 do:[:i|
		y _ self nextSampleY.
		cb _ self nextSampleCb.
		cb _ cb - SampleOffset.
		cr _ self nextSampleCr.
		cr _ cr - SampleOffset.
		red _ y + ((FIXn1n40200 * cr) // 65536) + (residuals at: RedIndex).
		red _ red min: MaxSample. red _ red max: 0.
		residuals at: RedIndex put: (red bitAnd: ditherMask).
		red _ red bitAnd: MaxSample - ditherMask.
		red _ red max: 1.
		green _ y - ((FIXn0n34414 * cb) // 65536) -
			((FIXn0n71414 * cr) // 65536) + (residuals at: GreenIndex).
		green _ green min: MaxSample. green _ green max: 0.
		residuals at: GreenIndex put: (green bitAnd: ditherMask).
		green _ green bitAnd: MaxSample - ditherMask.
		green _ green max: 1.
		blue _ y + ((FIXn1n77200 * cb) // 65536) + (residuals at: BlueIndex).
		blue _ blue min: MaxSample. blue _ blue max: 0.
		residuals at: BlueIndex put: (blue bitAnd: ditherMask).
		blue _ blue bitAnd: MaxSample - ditherMask.
		blue _ blue max: 1.
		jpegBits at: i put: 16rFF000000 + (red bitShift: 16) + (green bitShift: 8) + blue.
	].