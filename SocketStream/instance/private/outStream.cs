outStream
	outStream ifNil: [outStream _ WriteStream on: (self streamBuffer: self bufferSize)].
	^outStream