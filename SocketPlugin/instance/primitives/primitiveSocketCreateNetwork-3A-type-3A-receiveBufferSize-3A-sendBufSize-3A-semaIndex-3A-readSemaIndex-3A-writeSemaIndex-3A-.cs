primitiveSocketCreateNetwork: netType type: socketType receiveBufferSize: recvBufSize sendBufSize: sendBufSize semaIndex: semaIndex readSemaIndex: aReadSema writeSemaIndex: aWriteSema 
	| socketOop s okToCreate |
	self var: #s declareC: 'SocketPtr s'.
	self primitive: 'primitiveSocketCreate3Semaphores' parameters: #(#SmallInteger #SmallInteger #SmallInteger #SmallInteger #SmallInteger #SmallInteger #SmallInteger ).
	"If the security plugin can be loaded, use it to check for permission.
	If 
	not, assume it's ok"
	sCCSOTfn ~= 0
		ifTrue: [okToCreate _ self cCode: ' ((int (*) (int, int)) sCCSOTfn)(netType, socketType)'.
			okToCreate
				ifFalse: [^ interpreterProxy primitiveFail]].
	socketOop _ interpreterProxy instantiateClass: interpreterProxy classByteArray indexableSize: self socketRecordSize.
	s _ self socketValueOf: socketOop.
	self
		sqSocket: s
		CreateNetType: netType
		SocketType: socketType
		RecvBytes: recvBufSize
		SendBytes: sendBufSize
		SemaID: semaIndex
		ReadSemaID: aReadSema
		WriteSemaID: aWriteSema.
	^ socketOop