logIndent: aString
	| stream |
	stream := aString readStream.
	[ stream atEnd ] whileFalse: [
		self log: '	'.
		self log: stream nextLine.
		stream atEnd ifFalse: [ self cr ] ].
	self cr