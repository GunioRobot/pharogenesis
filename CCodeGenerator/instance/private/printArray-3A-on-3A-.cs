printArray: array on: aStream
	| first |
	first _ true.
	1 to: array size do:
		[:i |
		first 
			ifTrue: [first _ false]
			ifFalse: [aStream nextPutAll: ', '].
		i \\ 16 = 1 ifTrue: [aStream cr].
		self printInt: (array at: i) on: aStream]