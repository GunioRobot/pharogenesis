testIsEmpty
	| stream |
	stream := WriteStream on: String new.
	self assert: stream isEmpty.
	stream nextPut: $a.
	self deny: stream isEmpty.
	stream reset.
	self deny: stream isEmpty.