writeOn: aStream
	"This operation is illegal for mail inboxes."

	self error: 'Mail inboxes are read only!'