record

	self isInWorld ifFalse: [^ self].
	self stop.
	self writeCheck.
	self addJournalFile.
	tapeStream _ WriteStream on: (Array new: 10000).
	self resumeRecordIn: self world.
	self setStatusLight: #nowRecording.
