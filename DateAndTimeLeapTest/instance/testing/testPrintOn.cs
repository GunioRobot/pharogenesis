testPrintOn
	| cs rw |
	cs := ReadStream on: '2004-02-29T13:33:00+02:00'.
	rw := ReadWriteStream on: ''.
	aDateAndTime printOn: rw.
	self assert: rw contents = cs contents.
	cs  := ReadStream on: 'a TimeZone(UTC)'.
	rw := ReadWriteStream on: ''.
	aTimeZone printOn:  rw.
	self assert: rw contents = cs contents	