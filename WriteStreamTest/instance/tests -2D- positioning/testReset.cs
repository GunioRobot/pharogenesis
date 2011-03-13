testReset
	"self debug: #testReset"
	|stream stream2|
	stream := WriteStream with: 'a test ' copy.
	stream reset.
	stream nextPutAll: 'to test'.
	self assert: stream contents = 'to test'.

	stream2 := WriteStream with: 'a test ' copy.
	stream2 nextPutAll: 'to test'.
	self assert: stream2 contents = 'a test to test'