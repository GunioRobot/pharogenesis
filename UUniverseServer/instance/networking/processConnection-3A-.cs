processConnection: aConnection
	| message |
	aConnection isConnected ifFalse: [ ^self destroyConnection: aConnection ].
	
	aConnection processIO.
	[ 	message _ aConnection nextOrNil.
	  	message notNil
	] whileTrue: [
	  	self processRawMessage: message fromConnection: aConnection ].

	aConnection isConnected
		ifTrue: [ aConnection processIO.  "start sending out the response" ]
		ifFalse: [ self destroyConnection: aConnection ]