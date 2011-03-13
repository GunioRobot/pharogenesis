convertToSystemString

	| readStream writeStream converter |
	readStream := self readStream.
	writeStream := String new writeStream.
	converter := LanguageEnvironment defaultSystemConverter.
	converter ifNil: [^ self].
	[readStream atEnd] whileFalse: [
		converter nextPut: readStream next toStream: writeStream
	].
	converter emitSequenceToResetStateIfNeededOn: writeStream.
	^ writeStream contents.
