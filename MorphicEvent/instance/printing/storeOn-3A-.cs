storeOn: aStream

	aStream nextPutAll: type.
	aStream space.
	cursorPoint x storeOn: aStream.
	aStream space.
	cursorPoint y storeOn: aStream.
	aStream space.
	buttons storeOn: aStream.
	aStream space.
	keyValue storeOn: aStream.
