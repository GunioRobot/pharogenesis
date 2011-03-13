type: eventType readFrom: aStream
	type _ eventType.
	timeStamp _ Integer readFrom: aStream.
	aStream skip: 1.
	buttons _ Integer readFrom: aStream.
	aStream skip: 1.
	keyValue _ Integer readFrom: aStream.