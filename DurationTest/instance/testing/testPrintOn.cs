testPrintOn
	| cs rw |
	cs := '1:02:03:04.000000005' readStream.
	rw := ReadWriteStream on: ''.
	aDuration printOn: rw.
	self assert: rw contents = cs contents