messagesIn: category
	"Answer a collection of message ID's for the messages in the given category. The pseudo-categories are dynamically computed and so they cannot be accessed in this manner."

	^categories at: category ifAbsent: [#()]