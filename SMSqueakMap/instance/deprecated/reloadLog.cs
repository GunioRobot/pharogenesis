reloadLog
	"First we clear the current content and then we load the log.
	This should not lead to any differences!"

	users _ nil.
	categories _ nil.
	packages _ nil.
	accounts _ nil.
	objects _ Dictionary new.
	self loadLog