printOn: aStream
	name isNil ifTrue: [^ super printOn: aStream].
	aStream nextPutAll: name, ' phoneme set'