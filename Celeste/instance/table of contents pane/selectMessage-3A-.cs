selectMessage: id
	"Change the currently selected message."

	currentMsgID _ id.
	self changed: #tocEntry.
	self changed: #messageText
