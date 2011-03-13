testNextPut2
	"self debug: #testNextPut2"
	| stream |
	stream := WriteStream with: 'test'.
	stream nextPut: $s.
	self assert: stream contents = 'tests'