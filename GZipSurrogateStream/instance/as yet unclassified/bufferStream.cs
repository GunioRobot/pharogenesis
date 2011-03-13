bufferStream

	^bufferStream ifNil: [bufferStream _ RWBinaryOrTextStream on: (ByteArray new: 5000)].
