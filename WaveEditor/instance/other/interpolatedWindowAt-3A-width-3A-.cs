interpolatedWindowAt: index width: nSamples
	"Return an array of N samples starting at the given index in my data."

	| scale data baseIndex scaledFrac scaledOneMinusFrac prevSample nextSample v |
	scale _ 10000.
	data _ graph data.
	index isInteger
		ifTrue: [^ (index to: index + nSamples - 1) collect: [:i | data at: i]].
	baseIndex _ index truncated.
	scaledFrac _ ((index asFloat - baseIndex) * scale) truncated.
	scaledOneMinusFrac _ scale - scaledFrac.
	prevSample _ data at: baseIndex.
	^ (baseIndex + 1 to: baseIndex + nSamples) collect: [:i |
		nextSample _ data at: i.
		v _ ((nextSample * scaledFrac) + (prevSample * scaledOneMinusFrac)) // scale.
		prevSample _ nextSample.
		v].
