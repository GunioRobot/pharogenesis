fileRecordSize
	"Return the size of a Smalltalk file record in bytes."

	^ self cCode: 'sizeof(SQFile)'.