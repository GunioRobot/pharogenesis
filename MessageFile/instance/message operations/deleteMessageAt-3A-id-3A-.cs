deleteMessageAt: filePosition id: msgID
	"Mark as deleted the message with the given ID located at the given file position."

	self ensureFileIsOpen.
	self assertValidMessageAt: filePosition id: msgID.
	file position: filePosition.
	file nextPutAll: '&&&&&XXXXX'.		"delimiter for deleted messages"
	file flush.