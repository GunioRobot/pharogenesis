testPrintOn
	| cs rw |
	cs := ReadStream on: 'a Stopwatch(suspended:0:00:00:00)'.
	rw := ReadWriteStream on: ''.
	aStopwatch printOn: rw.
	self assert: rw contents = cs contents