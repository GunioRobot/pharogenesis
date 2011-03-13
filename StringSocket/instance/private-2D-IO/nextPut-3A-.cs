nextPut: anObject

	socketWriterProcess ifNil: [^self].
	outObjects addLast: anObject