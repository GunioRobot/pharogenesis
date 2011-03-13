printOn: aStream
	| count |
	aStream nextPutAll: '#('.
	count := 0.
	self do: [:each | 
		count := count + 1.
		each printOn: aStream.
		count < self size ifTrue: [aStream nextPut: $ ]
	].
	aStream nextPut: $).