testPrintOn
	| cs rw |
	cs := ReadStream on: '12:34:56 pm'.
	rw := ReadWriteStream on: ''.
	aTime printOn: rw.
	self assert: rw contents = cs contents