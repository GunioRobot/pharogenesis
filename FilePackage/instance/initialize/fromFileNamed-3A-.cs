fromFileNamed: aName
	| stream |
	fullName := aName.
	stream := FileStream readOnlyFileNamed: aName.
	stream setConverterForCode.
	[self fileInFrom: stream] ensure:[stream close].