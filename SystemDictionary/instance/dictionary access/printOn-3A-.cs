printOn: aStream

	aStream nextPutAll: 'a SystemDictionary'.
	(self == Smalltalk)
		ifTrue: [ aStream nextPutAll: ' (all the globals)' ].
