printOn: aStream

	aStream nextPutAll: 'Chunk('.
	id printOn: aStream base: 16.
	aStream 
		nextPut: $h;
		space;
		nextPutAll: name.
	Sensor commandKeyPressed ifTrue: [
		aStream space; nextPut: $<; nextPutAll: comment; nextPut: $>].
	aStream nextPut: $)