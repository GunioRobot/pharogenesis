testSpace
	"self debug: #testSpace"
	
	| stream |
	stream := WriteStream on: 'stream'.
	stream space.
	self assert: stream last = Character space.