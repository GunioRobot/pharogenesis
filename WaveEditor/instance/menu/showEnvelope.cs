showEnvelope
	"Show an envelope wave constructed by collecting the maximum absolute value of the samples in fixed-size time windows of mSecsPerQuantum."

	| data mSecsPerQuantum samplesPerQuantum result endOfQuantum maxThisQuantum s nSamples |
	data _ graph data.
	mSecsPerQuantum _ 10.
	samplesPerQuantum _ (mSecsPerQuantum / 1000.0) * self samplingRate.
	result _ WriteStream on: (Array new: data size // samplesPerQuantum).
	endOfQuantum _ samplesPerQuantum.
	maxThisQuantum _ 0.
	nSamples _ (data isKindOf: SoundBuffer)
		ifTrue: [data monoSampleCount]
		ifFalse: [data size].
	1 to: nSamples do: [:i |
		i asFloat > endOfQuantum ifTrue: [
			result nextPut: maxThisQuantum.
			maxThisQuantum _ 0.
			endOfQuantum _ endOfQuantum + samplesPerQuantum].
		s _ data at: i.
		s < 0 ifTrue: [s _ 0 - s].
		s > maxThisQuantum ifTrue: [maxThisQuantum _ s]].
	WaveEditor openOn: result contents.
