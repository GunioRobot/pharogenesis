printOn: aStream
	aStream nextPut: $(.
	self do: [:element | element printOn: aStream. aStream space].
	aStream nextPut: $)