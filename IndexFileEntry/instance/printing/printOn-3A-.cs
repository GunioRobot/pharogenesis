printOn: aStream

	aStream nextPutAll: self dateString; cr.
	aStream nextPutAll: from; cr.
	aStream nextPutAll: to; cr.
	aStream nextPutAll: cc; cr.
	aStream nextPutAll: subject; cr.
	aStream nextPut: $(; nextPutAll: location printString; space.
	aStream nextPutAll: textLength printString; nextPut: $).
	aStream cr.