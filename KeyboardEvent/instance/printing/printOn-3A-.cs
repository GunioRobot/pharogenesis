printOn: aStream

	aStream nextPut: $[.
	aStream nextPutAll: type.
	self controlKeyPressed ifTrue: [
		aStream nextPutAll: ' ''^'.
		aStream nextPut: (keyValue + $a asciiValue - 1) asCharacter.
	] ifFalse: [
		aStream nextPutAll: ' '''.
		aStream nextPut: self keyCharacter.
	].
	aStream nextPut: $'.
	aStream nextPut: $].