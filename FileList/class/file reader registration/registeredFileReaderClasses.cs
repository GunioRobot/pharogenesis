registeredFileReaderClasses
	
	FileReaderRegistry ifNil: [FileReaderRegistry _ OrderedCollection new].
	^ FileReaderRegistry

	