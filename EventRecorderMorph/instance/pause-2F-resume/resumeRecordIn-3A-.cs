resumeRecordIn: aWorld

	recHand _ aWorld activeHand ifNil: [aWorld primaryHand].
	recHand newKeyboardFocus: aWorld.
	recHand addEventListener: self.

	lastEvent _ nil.
	state _ #record.

	voiceRecorder ifNotNil:
		[voiceRecorder clearRecordedSound.
		voiceRecorder resumeRecording.
		startSoundEvent _ MorphicUnknownEvent new setType: #startSound argument: nil hand: nil stamp: Time millisecondClockValue.
		tapeStream nextPut: startSoundEvent].

	self synchronize.
