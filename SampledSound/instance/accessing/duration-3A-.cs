duration: seconds

	super duration: seconds.
	initialCount _ (seconds * self samplingRate asFloat) rounded.
