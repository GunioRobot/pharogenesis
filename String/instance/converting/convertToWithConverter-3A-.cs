convertToWithConverter: converter

	| readStream writeStream |
	readStream := self readStream.
	writeStream := String new writeStream.
	converter ifNil: [^ self].
	[readStream atEnd] whileFalse: [
		converter nextPut: readStream next toStream: writeStream
	].
	converter emitSequenceToResetStateIfNeededOn: writeStream.
	^ writeStream contents.
