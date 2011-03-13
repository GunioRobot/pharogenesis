type: eventType readFrom: aStream
	| x y |
	type _ eventType.
	timeStamp _ Integer readFrom: aStream.
	aStream skip: 1.
	x _ Integer readFrom: aStream.
	aStream skip: 1.
	y _ Integer readFrom: aStream.
	aStream skip: 1.
	buttons _ Integer readFrom: aStream.
	position _ x@y.
