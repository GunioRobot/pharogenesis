fileRecordSize
	"Return the size of a Smalltalk file record in bytes."
	self static: false.
	^ self cCode: 'sizeof(SQFile)'.