deleteAllMessages
	"delete all messages"
	1 to: self numMessages do: [ :num |
		self deleteMessage: num ]