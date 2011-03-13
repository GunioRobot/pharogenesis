clear
	filter _ nil.
	children _ #().
	self clearSelection.
	self changed: #list.
	self changed: #selection.
	self changed: #filter.