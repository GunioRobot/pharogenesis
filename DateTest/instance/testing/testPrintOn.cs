testPrintOn
	| cs rw |
	cs := ReadStream on: '23 January 2004'.
	rw := ReadWriteStream on: ''.
	aDate printOn: rw.
	self assert: rw contents = cs contents