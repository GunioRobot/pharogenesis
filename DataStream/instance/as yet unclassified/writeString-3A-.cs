writeString: aString
	"PRIVATE -- Write the contents of a String."

	aString size < 16384 
		ifTrue: [byteStream nextStringPut: aString]
		ifFalse: [self writeByteArray: aString].	"takes more space"