fetchMessageCount: msgCount ofExpectedTotal: expectedTotal fromPOPConnection: popConnection doFormatting: doFormatting
	"Download the given number of messages from the given open POP3 connection. If doFormatting is true, messages will be formatted as they are received."

	| nextID msgText msg location category |
	messageFile beginAppend.
	('Downloading ', msgCount printString, ' messages of ', expectedTotal printString, '...')
		displayProgressAt: Sensor mousePoint
		from: 0
		to: msgCount
		during: [:progressBar |
			1 to: msgCount do: [:messageNum |
				progressBar value: messageNum.
				popConnection isConnected ifFalse: [
					popConnection destroy.  "network error"
					messageFile endAppend.
					self saveDB.
					^ self inform: 'Server connection unexpectedly closed.'].

				"get a message"
				msgText _ popConnection retrieveMessage: messageNum.
				nextID _ self nextUnusedID.

				"save that message"
				msg _ MailMessage from: msgText.
				category _ self categoryForNewMessage: msg.
				doFormatting ifTrue: [msg format].
				location _ messageFile basicAppend: msg text id: nextID.
				indexFile
					at: nextID
					put: (IndexFileEntry
						message: msg
						location: location
						messageFile: messageFile
						msgID: nextID).
				self categorizer file: nextID inCategory: category.
				]].

	messageFile endAppend.
	self saveDB.
