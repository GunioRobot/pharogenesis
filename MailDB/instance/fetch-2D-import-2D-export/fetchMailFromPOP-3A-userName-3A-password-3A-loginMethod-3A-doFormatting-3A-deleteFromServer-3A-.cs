fetchMailFromPOP: server userName: userName password: password loginMethod: loginMethod doFormatting: doFormatting deleteFromServer: deleteFromServer
	"Download mail from the given POP3 mail server and append it this mail database. Answer the number of messages fetched. If doFormatting is true, messages will be formatted as they are received. If deleteFromServer is true, then messages will be removed from the POP3 server after being successfully retrieved. (Note: If there is a failure while fetching mail, all messages will be left on the server.)"

	| msgCount totalMessageCount downloadInChunks |
	popClient := nil.  "unfortunately, you can't tell if the requested userName is the same as it was last time.  Until that is fixed, it is safest to create a new POP3Client each time"

	"if downloading a lot of email, it is safer to download 100 messages at a time, and to delete those messages and reopen the connection between each group of messages.  POP is only required to delete the requested messages once the connection is closed, and thus it's good to close the connection occasionally."
	downloadInChunks := deleteFromServer.

	totalMessageCount := 0.

	"each time through this loop connects to the server, downloads a batch of messages, and possibly deletes them"
	[
		popClient :=
			self
				openPopConnectionTo: server
				forUser: userName
				password: password
				loginMethod: loginMethod.

		msgCount _ popClient messageCount.

		msgCount > 0
	] whileTrue: [
		downloadInChunks ifTrue: [
			msgCount := msgCount min: 100.  
		].

		[
			self fetchMessageCount: msgCount
				ofExpectedTotal: totalMessageCount + popClient messageCount
				fromPOPConnection: popClient
				doFormatting: doFormatting.

			deleteFromServer ifTrue: [
				self removeMessageCount: msgCount fromPOPConnection: popClient].

			popClient quit.

		] ensure: [
			popClient close.
			popClient := nil. ].

		totalMessageCount := totalMessageCount + msgCount.

		downloadInChunks ifFalse: [
			"only loop once if not downloading in chunks"
			^totalMessageCount ].
	].

	popClient ifNotNil: [
		popClient quit.
		popClient close. ].

	^ totalMessageCount