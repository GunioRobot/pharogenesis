delete
	"I must close my file handle before the file can be deleted."

	self close.
	super delete.