volumeEnvelopeScaledTo: scalePoint
	"Return a collection of values representing my volume envelope scaled by the given point. The scale point's x component is pixels/second and its y component is the number of pixels for full volume."

	| env amp vScale cnt oldT newT totalCnt |
	self error: 'not yet implemented'.

"old code:"
	totalCnt _ "initialCount" 1000.
	env _ Array new: (totalCnt * scalePoint x // self samplingRate min: 500).
	amp _ scaledVol asFloat / ScaleFactor.
	vScale _ scalePoint y asFloat / 1000.0.
	cnt _ totalCnt.
	oldT _ newT _ 0.  "Time in units of scale x per second"
	[cnt > 0 and: [newT <= env size]] whileTrue:
		[env atAll: (oldT+1 to: newT) put: (amp*vScale) asInteger.
		oldT _ newT.
		"amp _ amp * decayRate."
		cnt _ cnt - samplesUntilNextControl.
		newT _ totalCnt - cnt * scalePoint x // self samplingRate].
	env atAll: ((oldT+1 min: env size) to: env size) put: (amp*vScale) asInteger.
	^ env
