waitBrowserReadyFor: timeout ifFail: errorBlock
	| startTime delay okay |
	okay _ self primBrowserReady.
	okay ifNil:[^errorBlock value].
	okay ifTrue: [^true].
	startTime _ Time millisecondClockValue.
	delay _ Delay forMilliseconds: 100.
	[(Time millisecondsSince: startTime) < timeout]
		whileTrue: [
			delay wait.
			okay _ self primBrowserReady.
			okay ifNil:[^errorBlock value].
			okay ifTrue: [^true]].
	^errorBlock value