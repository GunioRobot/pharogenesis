viewSamples

	| stereoBuf |
	stereoBuf _ self computeSamplesForSeconds: self duration.
	WaveEditor openOn: stereoBuf extractLeftChannel.
