messageCount
	"if no socket, try to connect in background, when done, remove socket."
	socket
		ifNil: 
			[socket _ POPSocket new.
			
			[socket serverName: Celeste popServer.
			socket userName: Celeste popUserName.
			socket password: self password.
			"socket addProgressObserver: Transcript."
			([socket connectToPOP]
				on: Error do: 
				[Transcript show: 'Couldn''t connect to POP.';
				 cr. (Delay forSeconds: 180) wait.
				false])
				ifTrue: 
					[messageCount _ socket numMessages.
					socket disconnectFromPOP.
					lastConnectTime _ Time now].
			socket _ nil]
				forkAt: Processor userBackgroundPriority].
	^ messageCount