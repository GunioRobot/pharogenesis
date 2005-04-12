convertToSystemString

	| readStream writeStream converter |
	readStream _ self readStream.
	writeStream _ String new writeStream.
	converter _ LanguageEnvironment defaultSystemConverter.
	converter ifNil: [^ self].
	[readStream atEnd] whileFalse: [
		converter nextPut: readStream next toStream: writeStream
	].
	converter emitSequenceToResetStateIfNeededOn: writeStream.
	^ writeStream contents.
