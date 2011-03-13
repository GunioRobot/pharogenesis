initialize
	"Initialize the receiver (automatically called when instances are created via 'new')"

	super initialize.
	vocabularyName _ #unnamed.
	categories _ OrderedCollection new.
	methodInterfaces _ IdentityDictionary new.
	self documentation: 'A vocabulary that has not yet been documented'.
