initialize
	"Build a sine wave table."
	"FMSound initialize"

	| tableSize radiansPerStep peak |
	tableSize _ 4000.
	SineTable _ SoundBuffer newMonoSampleCount: tableSize.
	radiansPerStep _ (2.0 * Float pi) / tableSize asFloat.
	peak _ ((1 bitShift: 15) - 1) asFloat.  "range is +/- (2^15 - 1)"
	1 to: tableSize do: [:i |
		SineTable at: i put: (peak * (radiansPerStep * (i - 1)) sin) rounded].
