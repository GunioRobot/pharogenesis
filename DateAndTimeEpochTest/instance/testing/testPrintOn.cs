testPrintOn
	| cs rw |
	cs := ReadStream on: '1901-01-01T00:00:00+00:00'.
	rw := ReadWriteStream on: ''.
	aDateAndTime printOn: rw.
	self assert: rw contents = cs contents.
	cs  := ReadStream on: 'a TimeZone(ETZ)'.
	rw := ReadWriteStream on: ''.
	aTimeZone printOn:  rw.
	self assert: rw contents = cs contents