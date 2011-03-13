printOn: aStream
	components do: [ :comp | aStream nextPutAll: comp asString ].