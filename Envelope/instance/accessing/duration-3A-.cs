duration: seconds
	"Set the note duration to the given number of seconds."

	| totalMSecs |
	totalMSecs _ (seconds * 1000.0) asInteger.
	self sustainEnd: (totalMSecs - self decayTime).
