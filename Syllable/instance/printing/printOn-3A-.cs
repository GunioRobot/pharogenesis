printOn: aStream
	| first |
	aStream nextPut: $[.
	first _ true.
	self phonemes do: [ :each |
		first ifFalse: [aStream space].
		aStream print: each.
		first _ false].
	aStream nextPut: $]