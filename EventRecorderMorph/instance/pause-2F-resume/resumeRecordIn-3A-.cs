resumeRecordIn: aWorld

	recHand _ aWorld activeHand ifNil: [aWorld primaryHand].
	recHand newKeyboardFocus: aWorld.
	recHand startReportingEventsTo: self.

	lastEvent _ nil.
	state _ #record.

	voiceRecorder ifNotNil:
		[voiceRecorder clearRecordedSound.
		voiceRecorder resumeRecording.
		startSoundEvent _ MorphicSoundEvent new.
		startSoundEvent setCursorPoint: recHand lastEvent cursorPoint.
		tapeStream nextPut: 0 -> startSoundEvent].

	self synchronize.
