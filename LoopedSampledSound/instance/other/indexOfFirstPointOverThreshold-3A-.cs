indexOfFirstPointOverThreshold: threshold
	"Answer the index of the first sample whose absolute value exceeds the given threshold."

	| s |
	leftSamples == rightSamples
		ifTrue: [
			1 to: lastSample do: [:i |
				s _ leftSamples at: i.
				s < 0 ifTrue: [s _ 0 - s].
				s > threshold ifTrue: [^ i]]]
		ifFalse: [
			1 to: lastSample do: [:i |
				s _ leftSamples at: i.
				s < 0 ifTrue: [s _ 0 - s].
				s > threshold ifTrue: [^ i].
				s _ rightSamples at: i.
				s < 0 ifTrue: [s _ 0 - s].
				s > threshold ifTrue: [^ i]]].
	^ lastSample + 1
