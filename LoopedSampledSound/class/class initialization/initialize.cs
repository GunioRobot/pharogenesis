initialize
	"LoopedSampledSound initialize"

	LoopIndexScaleFactor _ 512.
	FloatLoopIndexScaleFactor _ LoopIndexScaleFactor asFloat.
	LoopIndexFractionMask _ LoopIndexScaleFactor - 1.
