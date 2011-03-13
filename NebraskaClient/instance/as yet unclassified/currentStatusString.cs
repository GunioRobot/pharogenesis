currentStatusString

	(connection isNil or: [connection isConnected not]) ifTrue: [^'nada'].
	^(NetNameResolver stringFromAddress: connection remoteAddress),
		' - ',
		(self backlog // 1024) printString,'k'