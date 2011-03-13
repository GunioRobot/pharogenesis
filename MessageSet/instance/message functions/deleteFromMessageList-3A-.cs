deleteFromMessageList: aMessage
	"Delete the given message from the receiver's message list"

	messageList _ messageList copyWithout: aMessage