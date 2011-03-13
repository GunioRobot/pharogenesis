setDur: d
	"Set duration in seconds."

	initialCount _ (d * self samplingRate asFloat) asInteger.
	count _ initialCount.
