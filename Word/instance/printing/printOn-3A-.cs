printOn: aStream
	aStream nextPutAll: (self isAccented ifTrue: [self string asUppercase] ifFalse: [self string])