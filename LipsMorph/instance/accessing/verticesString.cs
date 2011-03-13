verticesString
	| stream first |
	stream := WriteStream with: ''.
	stream nextPut: ${.
	first := true.
	vertices do: [ :each |
		first ifFalse: [stream nextPutAll: '. '].
		stream print: (each - self position) rounded.
		first := false].
	stream nextPut: $}.
	^ stream contents