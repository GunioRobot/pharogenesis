playLoop

	[true] whileTrue: [
		[self primSoundAvailableSpace > 0] whileFalse: [
			(Delay forMilliseconds: 1) wait.
		].

		PlayerSemaphore critical: [
			BufferReady ifTrue: [
				self primSoundPlaySamples: Buffer sampleCount from: Buffer startingAt: 1.
				Buffer primFill: 0.
				BufferReady _ false.
			] ifFalse: [
				self primSoundPlaySilence.
			].
		].

		PlayerSemaphore critical: [
			BufferReady ifFalse: [
				ActiveSounds copy do: [ :snd |
					snd samplesRemaining <= 0 ifTrue: [ ActiveSounds remove: snd ].
				].
				ActiveSounds do: [ :snd |
					snd playSampleCount: Buffer sampleCount into: Buffer startingAt: 1 stereo: Stereo.
					BufferReady _ true.
				].
			].
		].
	].

	PlayerProcess _ nil.