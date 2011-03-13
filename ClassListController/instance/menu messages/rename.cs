rename
	"Request to rename the currently selected class."
	self controlTerminate.
	model renameClass.
	self controlInitialize