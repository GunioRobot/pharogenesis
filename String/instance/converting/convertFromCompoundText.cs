convertFromCompoundText

	| readStream writeStream converter |
	readStream _ self readStream.
	writeStream _ String new writeStream.
	converter _ CompoundTextConverter new.
	converter ifNil: [^ self].
	[readStream atEnd] whileFalse: [
		writeStream nextPut: (converter nextFromStream: readStream)].
	^ writeStream contents
