listChanged
	"set newList to be the list of strings to display"
	listItems := Array new: self getListSize withAll: nil.
	selectedRow := nil.
	selectedRows := PluggableSet integerSet.
	maxWidth := nil. "recompute"
	self adjustHeight.
	self adjustWidth.
	self changed.
