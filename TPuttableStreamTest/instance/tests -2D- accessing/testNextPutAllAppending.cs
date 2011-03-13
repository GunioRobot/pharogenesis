testNextPutAllAppending
	| stream |
	stream := self emptyStream.
	self shouldnt: [
		stream
			nextPutAll: 'abc'.
	] raise: Error.