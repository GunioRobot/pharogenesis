nextPut: aCharacter toStream: aStream 
	| ch |
	aStream isBinary ifTrue: [^aCharacter storeBinaryOn: aStream].
	(ch := aCharacter squeakToMac) asciiValue > 255 
		ifTrue:[^self error: 'Cannot write wide characters'].
	aStream basicNextPut: ch.
