primitiveSocketAcceptFrom: sockHandle rcvBufferSize: recvBufSize sndBufSize: sendBufSize semaIndex: semaIndex 
	| socketOop s serverSocket |
	self var: #s declareC: 'SocketPtr s'.
	self var: #serverSocket declareC: 'SocketPtr serverSocket'.
	self primitive: 'primitiveSocketAccept'
		parameters: #(Oop SmallInteger SmallInteger SmallInteger ).
	serverSocket _ self socketValueOf: sockHandle.

	interpreterProxy failed
		ifFalse: [socketOop _ interpreterProxy instantiateClass: interpreterProxy classByteArray indexableSize: self socketRecordSize.
			s _ self socketValueOf: socketOop.
			self
				sqSocket: s
				AcceptFrom: serverSocket
				RecvBytes: recvBufSize
				SendBytes: sendBufSize
				SemaID: semaIndex].
	^ socketOop