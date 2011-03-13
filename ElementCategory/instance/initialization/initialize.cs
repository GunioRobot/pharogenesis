initialize
	"Initialize the receiver (automatically called when instances are created via 'new')"

	super initialize.
	keysInOrder _ OrderedCollection new.
	elementDictionary _ IdentityDictionary new