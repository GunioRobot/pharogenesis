add: aSound pan: leftRightPan volume: volume
	"Add the given sound with the given left-right pan, where 0.0 is full left, 1.0 is full right, and 0.5 is centered. The loudness of the sound will be scaled by volume, which ranges from 0 to 1.0."

	| pan vol |
	pan _ ((leftRightPan * ScaleFactor) asInteger max: 0) min: ScaleFactor.
	vol _ ((volume * ScaleFactor) asInteger max: 0) min: ScaleFactor.
	sounds _ sounds copyWith: aSound.
	leftVols _ leftVols copyWith: ((ScaleFactor - pan) * vol) // ScaleFactor.
	rightVols _ rightVols copyWith: (pan * vol) // ScaleFactor.
