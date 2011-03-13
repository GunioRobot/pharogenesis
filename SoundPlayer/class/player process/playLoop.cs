playLoop
	"The sound player process loop."

	| bytesPerSlice count willStop mayStop |
	mayStop _ Preferences soundStopWhenDone.
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
			willStop _ mayStop and:[
						(ActiveSounds size = 0) and:[
							self isAllSilence: Buffer size: count]].
			willStop
				ifTrue:[self shutDown. PlayerProcess _ nil]
				ifFalse:[Buffer primFill: 0].
			SoundJustStarted _ nil].
		willStop ifTrue:[^self].
	].
