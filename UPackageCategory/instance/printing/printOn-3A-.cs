printOn: aStream
	components do: [ :comp |
		aStream nextPutAll: comp ]
	separatedBy: [ aStream nextPut: $/ ]