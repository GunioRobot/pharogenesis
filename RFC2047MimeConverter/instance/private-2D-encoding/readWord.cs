readWord

	| strm |
	strm _ WriteStream on: (String new: 20)
	dataStream skipSeparators.
	[dataStream atEnd] whileFalse: 
		[ | c |
		c _ dataStream next.
		strm nextPut: c.
		c isSeparator ifTrue: [^ strm contents]].
	^ strm contents