testPrint24OnWithoutSeconds
	| cs rw |
	cs := ReadStream on: '12:34:56'.
	rw := ReadWriteStream on: ''.
	aTime print24: true showSeconds: true on: rw.
	self assert: rw contents = cs contents