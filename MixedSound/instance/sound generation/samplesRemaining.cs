samplesRemaining

	| remaining r |
	remaining _ 0.
	1 to: sounds size do: [:i |
		r _ (sounds at: i) samplesRemaining.
		r > remaining ifTrue: [remaining _ r]].

	^ remaining
