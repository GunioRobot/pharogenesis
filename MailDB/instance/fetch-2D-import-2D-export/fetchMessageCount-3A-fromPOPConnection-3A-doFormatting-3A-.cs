fetchMessageCount: msgCount fromPOPConnection: popConnection doFormatting: doFormatting
	"Download the given number of messages from the given open POP3 connection. If doFormatting is true, messages will be formatted as they are received."

	^self fetchMessageCount: msgCount ofExpectedTotal: msgCount fromPOPConnection: popConnection doFormatting: doFormatting