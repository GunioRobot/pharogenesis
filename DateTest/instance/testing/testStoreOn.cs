testStoreOn
	| cs rw |
	cs := ReadStream on: '''23 January 2004'' asDate'.
	rw := ReadWriteStream on: ''.
	aDate storeOn: rw.
	self assert: rw contents = cs contents