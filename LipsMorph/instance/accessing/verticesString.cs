verticesString
	| stream first |
	stream _ WriteStream with: ''.
	stream nextPut: ${.
	first _ true.
	vertices do: [ :each |
		first ifFalse: [stream nextPutAll: '. '].
		stream print: (each - self position) rounded.
		first _ false].
	stream nextPut: $}.
	^ stream contents