rename: newFileName
	"I must close my file handle before the file can be renamed."

	self close.
	super rename: newFileName.