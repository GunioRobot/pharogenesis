writeOn: aStream
	"This operation is illegal for news inboxes."

	self error: 'News inboxes are read only!'