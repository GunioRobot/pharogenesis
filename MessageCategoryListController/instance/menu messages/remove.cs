remove
	"Remove the messages in the selected category."

	self controlTerminate.
	model removeMessageCategory.
	self controlInitialize