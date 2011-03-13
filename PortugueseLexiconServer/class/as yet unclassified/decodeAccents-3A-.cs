decodeAccents: appleLikeString
	"change characters like �, to the form used in Portuguese"
	| encodedStream rem |
	encodedStream _ WriteStream on: (String new).
	
	appleLikeString do: [ :c |
		rem _ encodedStream position.
		c == $� ifTrue: [encodedStream nextPut: (Character value: 237)].
		c == $� ifTrue: [encodedStream nextPut: (Character value: 225)].
		c == $� ifTrue: [encodedStream nextPut: (Character value: 233)].
		c == $� ifTrue: [encodedStream nextPut: (Character value: 231)].
		c == $� ifTrue: [encodedStream nextPut: (Character value: 227)].
		c == $� ifTrue: [encodedStream nextPut: (Character value: 243)].
		c == $� ifTrue: [encodedStream nextPut: (Character value: 234)].
		"and more, such as e with a backwards accent"

		rem = encodedStream position ifTrue: [
			encodedStream nextPut: c].
		].
	^encodedStream contents. 