connectToSMTPServer: serverName
	"connect to the given server on the SMTP port"
	| addr |
	Socket initializeNetwork.
	addr _ NetNameResolver addressForName: serverName.
	addr ifNil: [self error: 'Could not find host address'].

	Transcript show: 'connecting to ', serverName, '...'.
	self connectTo: addr  port: 25.
	self waitForConnectionUntil: Socket standardDeadline.
	self isConnected ifFalse: [
		^false ].

	self checkSMTPResponse.

	self sendCommand: 'HELO aSqueakSystem'.
	self checkSMTPResponse.

	^true