reset
	"Details: The sample index and increment are scaled to allow fractional increments without having to do floating point arithmetic in the inner loop."

	super reset.
	scaledIncrement _
		((originalSamplingRate asFloat / self samplingRate) * IncrementScaleFactor) rounded.
	count _ initialCount.
	scaledIndex _ IncrementScaleFactor.  "index of the first sample, scaled"
	indexHighBits _ 0.
