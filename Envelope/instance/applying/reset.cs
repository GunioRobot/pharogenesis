reset
	"Reset the state for this envelope."

	lastValue _ -100000.0.  "impossible value"
	nextRecomputeTime _ 0.
	self updateTargetAt: 0.
