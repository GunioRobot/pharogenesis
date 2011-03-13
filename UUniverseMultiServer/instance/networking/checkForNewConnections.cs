checkForNewConnections
	connectionQueue ifNil: [ ^self ].
	[ connections size < 100 ] whileTrue: [
		| newSocket |
		newSocket _ connectionQueue getConnectionOrNil.
		newSocket ifNil: [ ^self ].
		connections add: (StringSocket on: newSocket) ].
	