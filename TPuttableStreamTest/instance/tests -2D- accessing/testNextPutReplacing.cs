testNextPutReplacing
	| stream |
	stream := self streamOnArray.
	stream reset.
	self shouldnt: [
		stream
			nextPut: $a;
			nextPut: $b;
			nextPut: $c.
	] raise: Error.