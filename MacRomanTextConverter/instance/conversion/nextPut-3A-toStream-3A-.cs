nextPut: aCharacter toStream: aStream 

	aStream isBinary ifTrue: [^aCharacter storeBinaryOn: aStream].
	aStream basicNextPut: aCharacter squeakToMac.
