segmentsAbove: threshold normalizedVolume: percentOfMaxVolume
	"Break the current recording up into a sequence of sound segments separated by silences."

	| max min sum totalSamples bufSize s dcOffset firstPlace endPlace resultBuf nFactor lastPlace segments gapSize minDur minLull soundSize restSize |
	stereo ifTrue: [self error: 'stereo trimming is not yet supported'].
	paused ifFalse: [self error: 'must stop recording before trimming'].
	(recordedSound == nil or: [recordedSound sounds isEmpty]) ifTrue:[^ self].
	"Reconstruct buffers so old trimming code will work"
	recordedBuffers _ recordedSound sounds collect: [:snd | snd samples].
	soundSize _ restSize _ 0.

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

	minDur _ (samplingRate/20.0) asInteger.  " 1/20 second "
	minLull _ (samplingRate/4.0) asInteger.  " 1/2 second "
	segments _ SequentialSound new.
	endPlace _ self endPlace.
	lastPlace _ #(1 1).
	[firstPlace _ self scanForStartThreshold: threshold
						dcOffset: dcOffset
						minDur: minDur
						startingAt: lastPlace.
	firstPlace = endPlace]
		whileFalse:
		[firstPlace = lastPlace ifFalse:
			["Add a silence equal to the gap size"
			"Wasteful but simple way to get gap size..."
			gapSize _ (self copyFrom: lastPlace to: firstPlace
						normalize: 1000 dcOffset: dcOffset) size - 2.
			"... -2 makes up for overlap of one sample on either end"
			segments add: (RestSound dur: gapSize asFloat / samplingRate).
			restSize _ restSize + gapSize.
"Transcript cr; print: firstPlace; space; print: lastPlace; space; print: gapSize; space; show: 'gap'."
			].
		lastPlace _ self scanForEndThreshold: threshold
						dcOffset: dcOffset
						minLull: minLull + minDur
						startingAt: firstPlace.
		"Allow room for lead time of next sound"
		lastPlace _ self place: lastPlace plus: minDur negated.
		nFactor _ self normalizeFactorFor: percentOfMaxVolume
						min: min max: max dcOffset: dcOffset.
		resultBuf _ self copyFrom: firstPlace to: lastPlace
						normalize: nFactor dcOffset: dcOffset.
		soundSize _ soundSize + resultBuf size.
"Transcript cr; print: firstPlace; space; print: lastPlace; space; print: resultBuf size; space; show: 'sound'."
		segments add: (codec == nil
			ifTrue: [SampledSound new setSamples: resultBuf samplingRate: samplingRate]
			ifFalse: [codec compressSound: (SampledSound new setSamples: resultBuf samplingRate: samplingRate)])].

	"Final gap for consistency"
	gapSize _ (self copyFrom: lastPlace to: self endPlace
				normalize: 1000 dcOffset: dcOffset) size - 1.
	segments add: (RestSound dur: gapSize asFloat / samplingRate).
	restSize _ restSize + gapSize.
	PopUpMenu notify: ((soundSize+restSize/samplingRate) roundTo: 0.1) printString , ' secs reduced to ' , ((soundSize/samplingRate) roundTo: 0.1) printString.
	recordedBuffers _ nil.
	^ segments