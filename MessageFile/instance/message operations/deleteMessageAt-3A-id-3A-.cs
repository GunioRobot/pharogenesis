deleteMessageAt: filePosition id: msgID
	"Mark as deleted the message with the given ID located at the given file position."

	self ensureFileIsOpen.
	(self assertValidMessageAt: filePosition id: msgID)
		ifFalse: [^false].		"Don't delete if it looks like we have a problem"

	file position: filePosition.
	file nextPutAll: '&&&&&XXXXX'.		"delimiter for deleted messages"
	file flush.