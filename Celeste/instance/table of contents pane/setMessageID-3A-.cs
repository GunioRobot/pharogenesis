setMessageID: newMessageID
	"Change the currently selected message.  Specify nil to choose no message"
	currentMsgID _ newMessageID.

	self changed: #tocIndex.
	Cursor read
		showWhile: [self changed: #messageText]