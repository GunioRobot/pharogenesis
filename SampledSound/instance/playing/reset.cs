reset
	"Details: The increment amount is represented as 1000 * the increment value to allow fractional increments without having to do floating point arithmetic in the inner loop."

	super reset.
	incrementTimes1000 _
		((originalSamplingRate asFloat / self samplingRate asFloat) * 1000.0) rounded.
	count _ initialCount.
	indexTimes1000 _ 1000.
