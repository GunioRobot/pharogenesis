loadAddressBookAsObjectFromFile: aFileName
	"Load the contact List and force a redraw"
	|rr dict|
	rr _ ReferenceStream fileNamed: aFileName.
	dict _ rr next.
	rr close.
	contactList _ dict.
	"I prefer to reset this value:"
	searchString _ ''.
	self changed: #searchString.
	self changed: #contactList.
