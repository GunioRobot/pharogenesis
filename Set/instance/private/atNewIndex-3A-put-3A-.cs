atNewIndex: index put: anObject
	array at: index put: anObject.
	tally _ tally + 1.
	self fullCheck