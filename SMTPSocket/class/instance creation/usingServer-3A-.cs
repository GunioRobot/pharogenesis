usingServer: serverName
	"Create a SMTP socket to the specified server for sending one or more mail messages"

	| sock |
	Socket initializeNetwork.
	sock _ self new.
	sock connectToSMTPServer: serverName.
	^sock