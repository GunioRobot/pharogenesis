writeOn: aStream
	filter ifNil: [^self].
	aStream binary; position: 0.
	filter writeOn: aStream.