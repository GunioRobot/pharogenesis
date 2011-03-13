processConnection: aConnection
	| message |
	aConnection isConnected ifFalse: [ ^self destroyConnection: aConnection ].
	
	"process all incoming messages.  Note that some messages move the connection to one of the subsidiary servers, so be careful not to process messages after that happens"
	aConnection processIO.
	[ 	(connections includes: aConnection) and: [
			message _ aConnection nextOrNil.
	 	 	message notNil ]
	] whileTrue: [
	  	self processRawMessage: message fromConnection: aConnection ].

	(connections includes: aConnection) ifFalse: [ ^self ].

	aConnection isConnected
		ifTrue: [ aConnection processIO.  "start sending out the response" ]
		ifFalse: [ self destroyConnection: aConnection ]
