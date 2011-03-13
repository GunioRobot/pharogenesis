record

	self isRecording: true.
	notesIndex = 0 ifFalse: [self notesListIndex: 0].
	sound _ nil.
	recorder clearRecordedSound.
	recorder resumeRecording.