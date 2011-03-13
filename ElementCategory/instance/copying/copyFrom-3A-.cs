copyFrom: donor
	"Copy the receiver's contents from the donor"

	keysInOrder _ donor keysInOrder.
	elementDictionary _ donor copyOfElementDictionary