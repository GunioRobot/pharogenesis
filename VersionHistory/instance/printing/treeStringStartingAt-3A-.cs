treeStringStartingAt: aVersion

	| strm |
	strm := WriteStream on: ''.
	self treeStringOn: strm startingAt: aVersion.
	^strm contents