testStoreOn
	| cs rw |
	cs := ReadStream on: '''12:34:56 pm'' asTime'.
	rw := ReadWriteStream on: ''.
	aTime storeOn: rw.
	self assert: rw contents = cs contents