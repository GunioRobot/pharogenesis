convertFromWithConverter: converter

	| readStream writeStream c |
	readStream _ self readStream.
	writeStream _ String new writeStream.
	converter ifNil: [^ self].
	[readStream atEnd] whileFalse: [
		c _ converter nextFromStream: readStream.
		c ifNotNil: [writeStream nextPut: c] ifNil: [^ writeStream contents]
	].
	^ writeStream contents
