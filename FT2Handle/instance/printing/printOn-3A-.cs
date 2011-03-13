printOn: aStream
	| handleHex |
	super printOn: aStream.
	handle isNil ifTrue: [ ^aStream nextPutAll: '<nil>' ].
	handleHex := (handle unsignedLongAt: 1 bigEndian: SmalltalkImage current isBigEndian) printStringHex.
	aStream nextPutAll: '<0x'; nextPutAll: handleHex; nextPut: $>.