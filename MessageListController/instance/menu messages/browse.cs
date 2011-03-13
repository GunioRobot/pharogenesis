browse
	"Create and schedule a message browser on the selected message."

	self controlTerminate.
	model buildMessageBrowser.
	self controlInitialize