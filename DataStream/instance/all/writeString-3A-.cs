writeString: aString
	"PRIVATE -- Write the contents of a String."

	(byteStream isKindOf: DummyStream) ifTrue: [^ self].
	aString size < 16384 
		ifTrue: [byteStream nextStringPut: aString]
		ifFalse: [self writeByteArray: aString].	"takes more space"