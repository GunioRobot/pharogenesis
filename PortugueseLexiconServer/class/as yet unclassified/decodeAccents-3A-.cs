decodeAccents: appleLikeString
	"change characters like í, to the form used in Portuguese"
	| encodedStream rem |
	encodedStream _ WriteStream on: (String new).
	
	appleLikeString do: [ :c |
		rem _ encodedStream position.
		c == $í ifTrue: [encodedStream nextPut: (Character value: 237)].
		c == $á ifTrue: [encodedStream nextPut: (Character value: 225)].
		c == $é ifTrue: [encodedStream nextPut: (Character value: 233)].
		c == $ç ifTrue: [encodedStream nextPut: (Character value: 231)].
		c == $ã ifTrue: [encodedStream nextPut: (Character value: 227)].
		c == $ó ifTrue: [encodedStream nextPut: (Character value: 243)].
		c == $ê ifTrue: [encodedStream nextPut: (Character value: 234)].
		"and more, such as e with a backwards accent"

		rem = encodedStream position ifTrue: [
			encodedStream nextPut: c].
		].
	^encodedStream contents. 