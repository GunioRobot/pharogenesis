testPosition
	"self debug: #testPosition"
	
	| stream |
	stream := WriteStream with: 'an elephant'.
	stream position: 6.
	self assert: stream contents = 'an ele'.

	stream nextPutAll: 'vator'.
	stream assert: stream contents = 'an elevator'