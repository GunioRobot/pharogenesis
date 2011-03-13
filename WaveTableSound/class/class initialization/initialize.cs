initialize
	"Build a sine wave table."
	"WaveTableSound initialize"

	| radiansPerStep scale |
	SineTable _ SoundBuffer new: 10000.
	radiansPerStep _ (2.0 * Float pi) / SineTable size asFloat.
	scale _ ((1 bitShift: 15) - 1) asFloat.  "range is +/- (2^15 - 1)"
	1 to: SineTable size do: [ :i |
		SineTable at: i put:
			(scale * (radiansPerStep * i) sin) rounded.
	].
