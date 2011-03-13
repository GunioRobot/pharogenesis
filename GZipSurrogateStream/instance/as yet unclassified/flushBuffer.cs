flushBuffer

	| data |
	bufferStream ifNil: [^self].
	data _ bufferStream contents asByteArray.
	gZipStream nextPutAll: data.
	positionThusFar _ positionThusFar + data size.
	bufferStream _ nil.
