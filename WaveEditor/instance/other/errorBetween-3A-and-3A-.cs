errorBetween: sampleArray1 and: sampleArray2
	"Answer the cummulative error between the two sample arrays, which are assumed to be the same size."

	| error e |
	error _ 0.
	1 to: sampleArray1 size do: [:i |
		e _ (sampleArray1 at: i) - (sampleArray2 at: i).
		e < 0 ifTrue: [e _ 0 - e].
		error _ error + e].
	^ error
