printOn: aStream
	| first |
	aStream
		nextPut: $[;
		nextPutAll: object printString;
		nextPutAll: ']-->('.
	first _ true.
	pointers do: [:node |
		first ifTrue: [first _ false] ifFalse: [aStream space].
		aStream nextPutAll: (node ifNil: ['*'] ifNotNil: [node object printString])].
	aStream nextPut: $)
