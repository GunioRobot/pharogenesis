slideFrom: startPoint to: stopPoint nSteps: nSteps 
	"does not display at the first point, but does at the last"
	| i p delta |
	i_0.  p_ startPoint.
	delta _ (stopPoint-startPoint) // nSteps.
	^ self follow: [p_ p+delta]
		while: [(i_i+1) < nSteps]