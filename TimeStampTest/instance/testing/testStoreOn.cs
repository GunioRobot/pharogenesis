testStoreOn
	| cs rw |
	cs := ReadStream on: '''2 January 2004 12:34:56 am'' asTimeStamp'.
	rw := ReadWriteStream on: ''.
	aTimeStamp storeOn: rw.
	self assert: rw contents = cs contents