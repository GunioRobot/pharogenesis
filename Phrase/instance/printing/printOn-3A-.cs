printOn: aStream
	self words do: [ :each | aStream print: each; space]