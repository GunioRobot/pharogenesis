duration: seconds

	super duration: seconds.
	count _ initialCount _ (seconds * self samplingRate) rounded.
