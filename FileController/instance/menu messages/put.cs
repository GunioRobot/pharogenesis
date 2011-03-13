put
	"Replace file contents with contents of view."

	self controlTerminate.
	model put: paragraph string.
	self unlockModel.
	self controlInitialize