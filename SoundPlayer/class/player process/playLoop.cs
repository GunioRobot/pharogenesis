playLoop
	"The sound player process loop."

	| bytesPerSlice count |
	bytesPerSlice _ Stereo ifTrue: [4] ifFalse: [2].
	[true] whileTrue: [
		[(count _ self primSoundAvailableBytes // bytesPerSlice) > 100]
			whileFalse: [ReadyForBuffer wait].

		count _ count min: Buffer stereoSampleCount.
		PlayerSemaphore critical: [
			ActiveSounds _ ActiveSounds select: [:snd | snd samplesRemaining > 0].
			ActiveSounds do: [:snd |
				snd ~~ SoundJustStarted ifTrue: [
					snd playSampleCount: count into: Buffer startingAt: 1]].
			ReverbState == nil ifFalse: [
				ReverbState applyReverbTo: Buffer startingAt: 1 count: count].
			self primSoundPlaySamples: count from: Buffer startingAt: 1.
			Buffer primFill: 0.
			SoundJustStarted _ nil]].
