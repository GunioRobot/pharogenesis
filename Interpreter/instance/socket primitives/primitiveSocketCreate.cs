primitiveSocketCreate

	| semaIndex sendBufSize recvBufSize socketType netType socketOop s |
	self var: #s declareC: 'SocketPtr s'.
	semaIndex	_ self stackIntegerValue: 0.
	sendBufSize	_ self stackIntegerValue: 1.
	recvBufSize	_ self stackIntegerValue: 2.
	socketType	_ self stackIntegerValue: 3.
	netType		_ self stackIntegerValue: 4.

	successFlag ifTrue: [
		socketOop _ self instantiateClass: (self splObj: ClassByteArray)
						indexableSize: self socketRecordSize.
		s _ self socketValueOf: socketOop.
		self sqSocket: s CreateNetType: netType SocketType: socketType
			RecvBytes: recvBufSize SendBytes: sendBufSize SemaID: semaIndex.
		successFlag ifTrue: [
			self pop: 6  "netType, socketType, recvBufSize, sendBufSize, semaIndex, rcvr"
				thenPush: socketOop.
		].
	].