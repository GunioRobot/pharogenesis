nextPutAll: aCollection
	aCollection do: [:v | self nextPut: v].
	^aCollection