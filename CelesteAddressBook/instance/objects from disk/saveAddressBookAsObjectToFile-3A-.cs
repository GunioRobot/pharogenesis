saveAddressBookAsObjectToFile: aFileName
	|rr|
	"Save the AB as a very crude object. Not funny but fast. gg"
	rr _ ReferenceStream fileNamed: aFileName.
	rr nextPut: contactList.
	rr close.
