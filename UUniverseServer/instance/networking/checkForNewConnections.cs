checkForNewConnections
	connectionQueue ifNil: [ ^self ].
	[ connections size < 10 ] whileTrue: [
		| newSocket |
		newSocket _ connectionQueue getConnectionOrNil.
		newSocket ifNil: [ ^self ].
		connections add: (StringSocket on: newSocket) ].
	