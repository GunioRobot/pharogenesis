testNextLineClosed
	| |
	stream1 nextPutAll: 'one'; crlf; flush.
	self assert: (stream2 nextLine = 'one').
	stream1 nextPutAll: 'two'; crlf; flush; close.
	self assert: (stream2 nextLine = 'two').
	self should: [stream2 nextLine] raise: ConnectionClosed
	