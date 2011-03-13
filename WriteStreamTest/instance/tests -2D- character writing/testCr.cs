testCr
	"self debug: #testCr"
	
	| stream |
	stream := WriteStream on: 'stream'.
	stream cr.
	self assert: stream last = Character cr.