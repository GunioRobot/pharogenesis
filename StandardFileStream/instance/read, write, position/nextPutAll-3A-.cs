nextPutAll: aString
	"Write all the characters of the given string to this file."

	rwmode ifFalse: [^ self error: 'Cannot write a read-only file'].
	self primWrite: fileID from: aString startingAt: 1 count: aString basicSize.
	^ aString
