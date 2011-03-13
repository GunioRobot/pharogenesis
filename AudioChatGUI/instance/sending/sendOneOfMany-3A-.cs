sendOneOfMany: aSampledSound

	| null message aCompressedSound ratio resultBuf oldSamples newCount t fromIndex val maxVal |

	self samplingRateForTransmission = aSampledSound originalSamplingRate ifTrue: [
		aCompressedSound _ mycodec compressSound: aSampledSound.
	] ifFalse: [
		t _ [
			ratio _ aSampledSound originalSamplingRate // self samplingRateForTransmission.
			oldSamples _ aSampledSound samples.
			newCount _ oldSamples monoSampleCount // ratio.
			resultBuf _ SoundBuffer newMonoSampleCount: newCount.
			fromIndex _ 1.
			maxVal _ 0.
			1 to: newCount do: [ :i |
				maxVal _ maxVal max: (val _ oldSamples at: fromIndex).
				resultBuf at: i put: val.
				fromIndex _ fromIndex + ratio.
			].
		] timeToRun.
		NebraskaDebug at: #soundReductionTime add: {t. maxVal}.
		maxVal < 400 ifTrue: [
			NebraskaDebug at: #soundReductionTime add: {'---dropped---'}.
			^self
		].		"awfully quiet"
		aCompressedSound _ mycodec compressSound: (
			SampledSound new 
				setSamples: resultBuf 
				samplingRate: aSampledSound originalSamplingRate // ratio
		).
	].

	null _ String with: 0 asCharacter.
	message _ {
		EToyIncomingMessage typeAudioChatContinuous,null. 
		Preferences defaultAuthorName,null.
		aCompressedSound samplingRate asInteger printString,null.
		aCompressedSound channels first.
	}.
	queueForMultipleSends ifNil: [
		queueForMultipleSends _ EToyPeerToPeer new 
			sendSomeData: message
			to: mytargetip
			for: self
			multiple: true.
	] ifNotNil: [
		queueForMultipleSends nextPut: message
	].

