convertToWithConverter: converter

	| readStream writeStream |
	readStream _ self readStream.
	writeStream _ String new writeStream.
	converter ifNil: [^ self].
	[readStream atEnd] whileFalse: [
		converter nextPut: readStream next toStream: writeStream
	].
	converter emitSequenceToResetStateIfNeededOn: writeStream.
	^ writeStream contents.
