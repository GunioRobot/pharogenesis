processIO
	| rawMsg |
	(stringSocket notNil and: [ stringSocket isConnected not ]) ifTrue: [
		"connection has died"
		stringSocket destroy.
		stringSocket _ nil ].

	
	(outMessages isEmpty not and: [ socket isNil and: [ stringSocket isNil ] ]) ifTrue: [
		"there are outgoing messages queued but there is no stringSocket"
		(DateAndTime now - lastConnectionStart) > (Duration minutes: 1) ifTrue: [
			self startConnecting ] ].
	
	socket ifNotNil: [
		"a connection is in progress"
		
		socket isConnected ifTrue: [
			"connection completed"
			stringSocket _ StringSocket on: socket.
			universe shortName ifNotNil: [
				outMessages addFirst: (UMProtocolVersion version: 1).
				outMessages addFirst: (UMSelectServer shortName: universe shortName) ].
			socket _ nil. ]
		ifFalse: [
			socket isWaitingForConnection ifFalse: [
				"the connection failed"
				inMessages add: (UMConnectionFailed description: 'connection failed').
				^self disconnect ] ] ].

	
	stringSocket ifNil: [ ^self ].
		
	[ outMessages isEmpty ] whileFalse: [
		stringSocket nextPut: outMessages removeFirst asStringArray ].
	
	stringSocket processIO.
	
	[	rawMsg _ stringSocket nextOrNil.
		rawMsg isNil not
	] whileTrue: [ 
		self newInMessage: (UMessage fromStringArray: rawMsg) ]