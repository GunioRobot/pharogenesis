slideFrom: startPoint to: stopPoint nSteps: nSteps delay: milliSecs
	"Slide this object across the display over the given number of steps, pausing for the given number of milliseconds after each step."
	"Note: Does not display at the first point, but does at the last."

	| i p delta |
	i _ 0.
	p _ startPoint.
	delta _ (stopPoint - startPoint) / nSteps asFloat.
	^ self
		follow: [(p _ p + delta) truncated]
		while: [
			(Delay forMilliseconds: milliSecs) wait.
			(i _ i + 1) < nSteps]
