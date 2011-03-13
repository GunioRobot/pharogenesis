performMenuMessage: aSelector
	"If a menu command is invoked, typeIn must be closed first, the selection
	 must be unhighlighted before and rehighlighted after, and the marker
	 must be updated."

	self closeTypeIn.
	self deselect.
	super performMenuMessage: aSelector.
	self selectAndScroll.
	self updateMarker