waitForReply: replySize for: timeOutDuration
	| startTime response delay bytesRead |
	startTime _ Time millisecondClockValue.
	response _ ByteArray new: replySize.
	bytesRead _ 0.
	delay _ Delay forMilliseconds: 500.
	[bytesRead < replySize
		and: [(Time millisecondClockValue - startTime) < timeOutDuration]] whileTrue: [
		bytesRead _ bytesRead + (self receiveDataInto: response).
		delay wait.
		Transcript show: '.'].
	bytesRead < replySize
		ifTrue: [self close; destroy.
				^ (ConnectionRefused host: self dstIP port: self dstPort) signal].
	^response