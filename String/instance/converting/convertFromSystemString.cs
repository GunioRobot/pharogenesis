convertFromSystemString

	| readStream writeStream converter |
	readStream _ self readStream.
	writeStream _ String new writeStream.
	converter _ LanguageEnvironment defaultSystemConverter.
	converter ifNil: [^ self].
	[readStream atEnd] whileFalse: [
		writeStream nextPut: (converter nextFromStream: readStream)].
	^ writeStream contents
