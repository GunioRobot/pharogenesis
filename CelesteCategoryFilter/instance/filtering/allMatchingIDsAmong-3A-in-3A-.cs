allMatchingIDsAmong: messageList in: mailDB
	^messageList intersection: (mailDB messagesIn: categoryName) asSet