printOn: aStream
	aStream nextPut: $[.
	aStream print: self selfSentSelectors asArray.
	aStream space.
	aStream print: self superSentSelectors asArray.
	aStream space.
	aStream print: self  classSentSelectors asArray.
	aStream nextPut: $].