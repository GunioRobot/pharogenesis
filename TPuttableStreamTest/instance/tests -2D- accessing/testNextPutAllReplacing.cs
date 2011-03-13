testNextPutAllReplacing
	| stream |
	stream := self streamOnString.
	stream reset.
	self shouldnt: [
		stream
			nextPutAll: 'abc'.
	] raise: Error.