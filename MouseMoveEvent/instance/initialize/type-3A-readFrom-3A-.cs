type: eventType readFrom: aStream
	| x y |
	super type: eventType readFrom: aStream.
	aStream skip: 1.
	x _ Integer readFrom: aStream.
	aStream skip: 1.
	y _ Integer readFrom: aStream.
	startPoint _ x@y.