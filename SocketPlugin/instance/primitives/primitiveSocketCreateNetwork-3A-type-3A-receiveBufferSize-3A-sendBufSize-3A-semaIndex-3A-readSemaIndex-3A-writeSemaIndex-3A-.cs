primitiveSocketCreateNetwork: netType type: socketType receiveBufferSize: recvBufSize sendBufSize: sendBufSize semaIndex: semaIndex readSemaIndex: aReadSema writeSemaIndex: aWriteSema


	| socketOop s |
	self var: #s declareC: 'SocketPtr s'.
	self primitive: 'primitiveSocketCreate3Semaphores'
		parameters: #(SmallInteger SmallInteger SmallInteger SmallInteger SmallInteger SmallInteger SmallInteger).

	socketOop _ interpreterProxy instantiateClass: interpreterProxy classByteArray
					indexableSize: self socketRecordSize.
	s _ self socketValueOf: socketOop.
	self sqSocket: s CreateNetType: netType SocketType: socketType
		RecvBytes: recvBufSize SendBytes: sendBufSize SemaID: semaIndex ReadSemaID: aReadSema WriteSemaID: aWriteSema.
	^socketOop