getListSelector: sel
	"Set the receiver's getListSelector as indicated, and trigger a recomputation of the list"

	getListSelector _ sel.
	self changed.
	self updateList.