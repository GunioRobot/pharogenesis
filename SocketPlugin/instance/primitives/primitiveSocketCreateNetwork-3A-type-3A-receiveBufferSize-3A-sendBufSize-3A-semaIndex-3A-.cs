primitiveSocketCreateNetwork: netType type: socketType receiveBufferSize: recvBufSize sendBufSize: sendBufSize semaIndex: semaIndex


	| socketOop s |
	self var: #s declareC: 'SocketPtr s'.
	self primitive: 'primitiveSocketCreate'
		parameters: #(SmallInteger SmallInteger SmallInteger SmallInteger SmallInteger).

	socketOop _ interpreterProxy instantiateClass: interpreterProxy classByteArray
					indexableSize: self socketRecordSize.
	s _ self socketValueOf: socketOop.
	self sqSocket: s CreateNetType: netType SocketType: socketType
		RecvBytes: recvBufSize SendBytes: sendBufSize SemaID: semaIndex.
	^socketOop