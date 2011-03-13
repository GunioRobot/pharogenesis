testNextPutAppending
	| stream |
	stream := self emptyStream.
	self shouldnt: [
		stream
			nextPut: $a;
			nextPut: $b;
			nextPut: $c.
	] raise: Error.