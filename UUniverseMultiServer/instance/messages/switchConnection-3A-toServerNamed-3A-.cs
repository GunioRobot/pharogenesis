switchConnection: aConnection  toServerNamed: serverName
	| server |
	server _ servers detect: [ :s | s universe shortName = serverName ] ifNone: [
		aConnection nextPut: (UMError description: 'no such server here') asStringArray.
		^self ].

	server acceptConnection: aConnection.
	connections remove: aConnection.
