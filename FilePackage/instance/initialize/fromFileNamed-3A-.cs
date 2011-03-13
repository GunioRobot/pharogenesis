fromFileNamed: aName
	| stream |
	fullName := aName.
	stream := FileStream readOnlyFileNamed: aName.
	self fileInFrom: stream.