printOn: aStream 
	aStream nextPut: $<.
	super printOn: aStream.
	self z = 0 ifFalse: [aStream nextPut: $@. self z printOn: aStream].
	aStream nextPut: $>