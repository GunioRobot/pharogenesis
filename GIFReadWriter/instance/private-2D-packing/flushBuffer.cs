flushBuffer
	bufStream isEmpty ifTrue: [^self].
	self nextPut: bufStream size.
	self nextPutAll: bufStream contents.
	bufStream _ WriteStream on: (ByteArray new: 256)