basicAppend: messageText id: messageID
	"Append the given message text with the given message ID. Answer the new location of the message."
	"WARNING: This operation assumes:
		1. the sender positioned the stream to the end of the file (using beginAppend), and
		2. the sender will do an endAppend operation after all messages are appended to flush all file buffers to disk."

	| location |
	file setToEnd.
	location _ file position.
	file nextPutAll: '&&&&&start'.	"message delimiter"
	file cr.
	messageID printOn: file.		"message ID"
	file cr.
	file nextPutAll: messageText.
	^location