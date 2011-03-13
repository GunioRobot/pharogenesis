type: eventType readFrom: aStream
	super type: eventType readFrom: aStream.
	aStream skip: 1.
	whichButton _ Integer readFrom: aStream.