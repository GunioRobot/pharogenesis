printOn: aStream
	| first |
	aStream nextPut: $[.
	first := true.
	self phonemes do: [ :each |
		first ifFalse: [aStream space].
		aStream print: each.
		first := false].
	aStream nextPut: $]