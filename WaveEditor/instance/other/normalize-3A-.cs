normalize: sampleArray
	"Return a copy of the given sample array scaled to use the maximum 16-bit sample range. Remove any D.C. offset."

	| max abs scale out |
	max _ 0.
	sampleArray do: [:s |
		s > 0 ifTrue: [abs _ s] ifFalse: [abs _ 0 - s].
		abs > max ifTrue: [max _ abs]].
	scale _ ((1 << 15) - 1) asFloat / max.

	out _ sampleArray species new: sampleArray size.
	1 to: sampleArray size do: [:i |
		out at: i put: (scale * (sampleArray at: i)) truncated].
	^ out
