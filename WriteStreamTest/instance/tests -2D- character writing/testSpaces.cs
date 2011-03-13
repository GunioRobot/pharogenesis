testSpaces
	"self debug: #testSpaces"
	
	| stream |
	stream := WriteStream on: 'stream'.
	stream space: 3.
	self assert: (stream contents last: 3) = '   '