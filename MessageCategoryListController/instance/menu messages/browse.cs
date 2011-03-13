browse
	"Create and schedule a message category browser on the selected message 
	category."

	self controlTerminate.
	model buildMessageCategoryBrowser.
	self controlInitialize