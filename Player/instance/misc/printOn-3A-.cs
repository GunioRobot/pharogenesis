printOn: aStream
	super printOn: aStream.
	aStream nextPutAll: (' (', self asOop printString, ')').
	self costume ifNil: [aStream nextPutAll: ' (with nil costume)'.  ^ self].
	aStream nextPutAll: ' named ', self externalName