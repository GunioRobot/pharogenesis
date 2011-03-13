testNextPutAll
	"self debug: #testNextPutAll"
	| stream |
	stream := WriteStream on: String new.
	stream
		nextPutAll: #($t $e $s $t).
	self assert: stream contents = 'test'