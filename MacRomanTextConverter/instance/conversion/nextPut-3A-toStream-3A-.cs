nextPut: aCharacter toStream: aStream 

	aStream isBinary ifTrue: [
		aCharacter class == Character ifTrue: [
			aStream basicNextPut: aCharacter.
			^ aStream.
		].
		aCharacter class == MultiCharacter ifTrue: [
			aStream nextInt32Put: aCharacter value.
			^ aStream.
		].
	].
	aStream basicNextPut: aCharacter isoToSqueak.
