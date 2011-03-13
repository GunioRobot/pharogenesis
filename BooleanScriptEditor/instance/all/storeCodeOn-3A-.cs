storeCodeOn: aStream
	(submorphs size > 0 and: [submorphs first submorphs size > 0]) ifTrue:
		[aStream nextPutAll: '(('.
		super storeCodeOn: aStream.
		aStream nextPutAll: ') ~~ false)'.
		^ self].
	aStream nextPutAll: ' true '