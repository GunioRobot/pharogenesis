copyFrom: donor
	"Copy the receiver's contents from the donor"

	keysInOrder := donor keysInOrder.
	elementDictionary := donor copyOfElementDictionary