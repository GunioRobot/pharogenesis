testPrintOn
	| cs rw |
	cs := ReadStream on: '2 January 2004 12:34:56 am'.
	rw := ReadWriteStream on: ''.
	aTimeStamp printOn: rw.
	self assert: rw contents = cs contents