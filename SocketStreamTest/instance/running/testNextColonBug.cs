testNextColonBug
	"stream2 timeout: 1.
	stream1 nextPutAll: '12345678'; flush.
	stream2 next: 4.
	self should: [stream2 next: 8] raise: ConnectionTimedOut"
	"md: doesn't timeOut for me... just hangs".