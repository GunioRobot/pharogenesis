record

	self isInWorld ifFalse: [^ self].
	self stop.
	self writeCheck.

	journalFile ifNotNil:
		[journalFile close.
		journalFile _ FileStream newFileNamed: 'EventRecorder.tape'].
	tapeStream _ WriteStream on: (Array new: 10000).
	self resumeRecordIn: self world.
	statusLight color: Color red.
