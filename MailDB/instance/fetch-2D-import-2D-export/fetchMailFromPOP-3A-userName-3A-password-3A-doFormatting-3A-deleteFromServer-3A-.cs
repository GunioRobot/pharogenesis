fetchMailFromPOP: server userName: userName password: password doFormatting: doFormatting deleteFromServer: deleteFromServer
	"Download mail from the given POP3 mail server and append it this mail database. Answer the number of messages fetched. If doFormatting is true, messages will be formatted as they are received. If deleteFromServer is true, then messages will be removed from the POP3 server after being successfully retrieved. (Note: If there is a failure while fetching mail, all messages will be left on the server.)"

	| popConnection msgCount |
	Socket initializeNetwork.
	popConnection _ POPSocket new
		serverName: server;	
		userName: userName;
		password: password;
		addProgressObserver: Transcript.
	Utilities
		informUser: 'connecting to ', server
		during: [popConnection connectToPOP].
	popConnection isConnected ifFalse: [^ -1].

	msgCount _ popConnection numMessages.
	msgCount > 0 ifTrue: [
		self fetchMessageCount: msgCount
			fromPOPConnection: popConnection
			doFormatting: doFormatting.

		deleteFromServer ifTrue: [
			self removeMessageCount: msgCount fromPOPConnection: popConnection]].

	popConnection disconnectFromPOP.
	^ msgCount
