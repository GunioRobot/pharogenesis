colorConvertGrayscaleMCU
	| y |
	yComponent at: CurrentXIndex put: 0.
	yComponent at: CurrentYIndex put: 0.
	0 to: jpegBitsSize-1 do:[:i|
		y _ self nextSampleY.
		y _ y + (residuals at: GreenIndex).
		y _ y min: MaxSample.
		residuals at: GreenIndex put: (y bitAnd: ditherMask).
		y _ y bitAnd: MaxSample - ditherMask.
		y _ y max: 1.
		jpegBits at: i put: 16rFF000000 + (y<<16) + (y<<8) + y.
	].