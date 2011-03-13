printAsSelfEvaluatingFormOn: aStream

	aStream nextPut: ${.
	self do: [:el | aStream print: el] separatedBy: [ aStream nextPutAll: '. '].
	aStream nextPut: $}