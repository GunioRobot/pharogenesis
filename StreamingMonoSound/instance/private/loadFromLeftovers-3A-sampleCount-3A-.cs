loadFromLeftovers: aSoundBuffer sampleCount: sampleCount
	"Load the given sound buffer from the samples leftover from the last frame. Answer the number of samples loaded, which typically is less than sampleCount."

	| leftoverCount n |
	leftoverCount _ leftoverSamples monoSampleCount.
	leftoverCount = 0 ifTrue: [^ 0].

	n _ leftoverCount min: sampleCount.
	1 to: n do: [:i | aSoundBuffer at: i put: (leftoverSamples at: i)].
	n < sampleCount
		ifTrue: [leftoverSamples _ SoundBuffer new]
		ifFalse: [leftoverSamples _ leftoverSamples copyFrom: n + 1 to: leftoverSamples size].
	^ n
