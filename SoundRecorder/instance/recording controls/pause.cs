pause
	"Go into pause mode. The record level continues to be updated, but no sound is recorded."

	paused _ true.
	((currentBuffer ~~ nil) and: [nextIndex > 1])
		ifTrue: [
			recordedBuffers addLast: (currentBuffer copyFrom: 1 to: nextIndex - 1).
			self allocateBuffer].

	soundPlaying ifNotNil: [
		soundPlaying pause.
		soundPlaying _ nil].

	CanRecordWhilePlaying ifFalse: [self stopRecording].
