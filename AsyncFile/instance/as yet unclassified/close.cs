close

	fileHandle ifNil: [^ self].  "already closed"
	self primClose: fileHandle.
	Smalltalk unregisterExternalObject: semaphore.
	semaphore _ nil.
	fileHandle _ nil.
