convertToSystemString: aString

	| readStream writeStream |
	readStream := aString readStream.
	writeStream := String new writeStream.

	[readStream atEnd] whileFalse: [
		self nextPut: readStream next toStream: writeStream
	].
	self emitSequenceToResetStateIfNeededOn: writeStream.
	^writeStream contents