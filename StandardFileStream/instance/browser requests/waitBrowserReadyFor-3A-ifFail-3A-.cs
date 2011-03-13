waitBrowserReadyFor: timeout ifFail: errorBlock
	| startTime delay |
	self primBrowserReady
		ifTrue: [^true].
	startTime _ Time millisecondClockValue.
	delay _ Delay forMilliseconds: 100.
	[(Time millisecondsSince: startTime) < timeout]
		whileTrue: [
			delay wait.
			self primBrowserReady
				ifTrue: [^true]].
	^errorBlock value