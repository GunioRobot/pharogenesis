tempsAndValues

	| string aStream |
	string _ super tempsAndValues.
	self myEnv ifNil: [^ string].

	aStream _ WriteStream on: (String new: 100).
	self capturedTempNames
		doWithIndex: [:title :index |
			aStream nextPutAll: title; nextPut: $:; space; tab.
			(self myEnv at: index) printOn: aStream.
			aStream cr].
	^ string, aStream contents