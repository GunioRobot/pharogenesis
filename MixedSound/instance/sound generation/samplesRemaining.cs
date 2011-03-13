samplesRemaining

	| remaining r |
	remaining _ 0.
	sounds do: [ :snd |
		r _ snd samplesRemaining.
		r > remaining ifTrue: [ remaining _ r ].
	].
	^ remaining