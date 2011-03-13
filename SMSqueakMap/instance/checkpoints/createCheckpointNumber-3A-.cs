createCheckpointNumber: number
	"Export me using an ImageSegment.
	This is used for checkpointing the map on disk
	in a form that can be brought into an independent image.
	We do not overwrite older versions, since using ImageSegments
	is an intermediate hack anyway we don't care about the disk waste!
	Sidenote: Some refactoring was needed to produce a .gz file directly so
	I didn't bother."

	| is fname stream oldMutex |
	fname := self filename, '.', number asString, '.s'.
	(self directory fileExists: fname) ifTrue: [self error: 'Checkpoint already exists!'].
	stream := StandardFileStream newFileNamed: (self directory fullNameFor: fname).
	checkpointNumber := number.
	oldMutex := mutex.
	mutex := nil. self clearCaches.
	[is := ImageSegment new.
	is copyFromRoots: (Array with: self) sizeHint: 1000000 areUnique: true.
	is writeForExportOn: stream.
	self compressFile: (StandardFileStream oldFileNamed: (self directory fullNameFor: fname)).
	isDirty := false]
		ensure: [mutex := oldMutex].
	^is