removeSelections
	"Remove all selected items from the list.  9/18/96 sw"

	self controlTerminate.
	model removeSelections.
	self controlInitialize