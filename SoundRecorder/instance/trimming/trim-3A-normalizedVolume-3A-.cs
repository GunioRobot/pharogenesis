trim: threshold normalizedVolume: percentOfMaxVolume
	"Remove the leading and trailing parts of this recording that are below the given threshold. Remove any DC offset and scale the recording so that its peaks are the given percent of the maximum volume."

	| max min sum totalSamples bufSize s dcOffset startPlace endPlace resultBuf nFactor |
	stereo ifTrue: [self error: 'stereo trimming is not yet supported'].
	paused ifFalse: [self error: 'must stop recording before trimming'].
	recordedBuffers _ recordedSound sounds collect: [:snd | snd samples].
	recordedBuffers isEmpty ifTrue: [^ self].

	max _ min _ sum _ totalSamples _ 0.
	recordedBuffers do: [:buf |
		bufSize _ buf size.
		totalSamples _ totalSamples + buf size.
		1 to: bufSize do: [:i |
			s _ buf at: i.
			s > max ifTrue: [max _ s].
			s < min ifTrue: [min _ s].
			sum _ sum + s]].
	dcOffset _ sum // totalSamples.

	"a place is an array of <buffer index><index of sample in buffer>"
	startPlace _ self scanForStartThreshold: threshold
					dcOffset: dcOffset
					minDur: (samplingRate/60.0) asInteger "at least 1/60th of a second"
					startingAt: #(1 1).
	startPlace = self endPlace ifTrue:
		["no samples above threshold"
		recordedBuffers _ nil.  ^ self].

	endPlace _ self scanForEndThreshold: threshold
					dcOffset: dcOffset
					minLull: (samplingRate/5) asInteger
					startingAt: startPlace.
	nFactor _ self normalizeFactorFor: percentOfMaxVolume min: min max: max dcOffset: dcOffset.
	resultBuf _ self copyFrom: startPlace to: endPlace normalize: nFactor dcOffset: dcOffset.
	recordedSound _ SampledSound new setSamples: resultBuf samplingRate: samplingRate.
	recordedBuffers _ nil
