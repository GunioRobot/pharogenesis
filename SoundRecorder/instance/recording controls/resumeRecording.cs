resumeRecording
	"Continue recording from the point at which it was last paused."

	CanRecordWhilePlaying ifFalse: [self startRecording].
	paused _ false.
