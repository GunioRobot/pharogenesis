listChanged
	"set newList to be the list of strings to display"
	listItems := Array new: self getListSize withAll: nil.
	selectedRow := nil.
	selectedRows := PluggableSet integerSet.
	self adjustHeight.
	self adjustWidth.
	self changed.
