next: anInteger putAll: aString startingAt: startIndex
	"Store the next anInteger elements from the given collection."
	rwmode ifFalse: [^ self error: 'Cannot write a read-only file'].
	self primWrite: fileID from: aString startingAt: startIndex count: anInteger.
	^aString