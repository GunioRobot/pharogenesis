append: messageText id: messageID
	"Append the given message text with the given unique identifier. Answer the new location of the message."

	| location |
	self beginAppend.
	location _ self basicAppend: messageText id: messageID.
	self endAppend.
	^location