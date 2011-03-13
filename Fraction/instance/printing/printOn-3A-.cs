printOn: aStream
	self asFloat printOn: aStream
	"aStream nextPut: $(.
	numerator printOn: aStream.
	aStream nextPut: $/.
	denominator printOn: aStream.
	aStream nextPut: $)"