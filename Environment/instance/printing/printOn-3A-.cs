printOn: aStream
	envtName
		ifNil: [aStream nextPutAll: self name]
		ifNotNil: [aStream nextPutAll: 'An Environment named '; nextPutAll: envtName]