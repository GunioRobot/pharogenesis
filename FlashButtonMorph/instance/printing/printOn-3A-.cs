printOn: aStream
	super printOn: aStream.
	events ifNil:[^self].
	aStream nextPut:$[.
	events keys do:[:k| aStream print: k; space].
	aStream nextPut: $].