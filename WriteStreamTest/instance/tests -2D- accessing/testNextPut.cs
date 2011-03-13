testNextPut
	"self debug: #testNextPut"
	| stream |
	stream := WriteStream on: String new.
	stream
		nextPut: $t;
		nextPut: $e;
		nextPut: $s;
		nextPut: $t.
	self assert: stream contents = 'test'