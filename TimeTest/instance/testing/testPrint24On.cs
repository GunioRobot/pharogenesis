testPrint24On
	| cs rw |
	cs := ReadStream on: '12:34:56'.
	rw := ReadWriteStream on: ''.
	aTime print24: true on: rw.
	self assert: rw contents = cs contents