printOn: aStream
	self phrases do: [ :each | aStream print: each; nextPutAll: '- ']