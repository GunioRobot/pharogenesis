nextPut: aCharacter toStream: aStream

	aStream isBinary ifTrue: [
		aCharacter class == Character ifTrue: [
			aStream basicNextPut: aCharacter charCode.
			^ aStream.
		].
		aCharacter class == MultiCharacter ifTrue: [
			aStream nextInt32Put: aCharacter charCode.
			^ aStream.
		].
	].
	aCharacter charCode < 128 ifTrue: [
		aStream basicNextPut: aCharacter.
	] ifFalse: [
		aStream basicNextPut: ((Character value: (self fromSqueak: aCharacter) charCode)).
	].

