printOn: aStream
	| count |
	aStream nextPutAll: '#('.
	count _ 0.
	self do: [:each | 
		count _ count + 1.
		each printOn: aStream.
		count < self size ifTrue: [aStream nextPut: $ ]
	].
	aStream nextPut: $).