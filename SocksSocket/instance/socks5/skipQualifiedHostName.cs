skipQualifiedHostName

	| startTime response bytesRead |
	startTime _ Time millisecondClockValue.
	response _ ByteArray new: 1.

	[(bytesRead _ self receiveDataInto: response) < 1
		and: [(Time millisecondClockValue - startTime) < self defaultTimeOutDuration]] whileTrue.

	bytesRead < 1
		ifTrue: [self socksError: 'Time out reading data'].

	self waitForReply: (response at: 1) + 2 for: self defaultTimeOutDuration