removeMessageCount: msgCount fromPOPConnection: popConnection
	"Remove messages 1 through msgCount from the given POP3 server."

	('Removing ', msgCount printString, ' messages from the server...')
		displayProgressAt: Sensor mousePoint
		from: 0
		to: msgCount
		during: [:progressBar |
			1 to: msgCount do: [:messageNum |
				progressBar value: messageNum.
				popConnection isConnected ifFalse: [
					popConnection destroy.  "network error"
					^ self inform: 'Server connection unexpectedly closed.'].
				popConnection deleteMessage: messageNum]].
