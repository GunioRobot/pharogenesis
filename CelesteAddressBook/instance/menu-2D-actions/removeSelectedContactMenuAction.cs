removeSelectedContactMenuAction
	|elem|
	elem _ self selectedContactItem.
	contactList removeKey: elem.
	"Update the gui, please:"
	self changed: #contactList.