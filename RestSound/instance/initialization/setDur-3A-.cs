setDur: d
	"Set rest duration in seconds."

	initialCount _ (d * self samplingRate asFloat) rounded.
	count _ initialCount.
	self reset.
