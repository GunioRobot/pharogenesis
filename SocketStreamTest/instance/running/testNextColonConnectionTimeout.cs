testNextColonConnectionTimeout
	"
	stream1 nextPutAll: '12345'; flush.
	stream2 timeout: 1.
	self should: [stream2 next: 10] raise: ConnectionTimedOut.
	stream1 nextPutAll: '67890'; flush.
	self assert: (stream2 next: 10) size = 10
	"
