initializeFor: anObject
	"Initialize the receiver to bear a vocabulary suitable for anObject"

	object _ anObject.
	vocabularyName _ #unnamed.
	categories _ OrderedCollection new.
	methodInterfaces _ IdentityDictionary new.
	self documentation: 'A vocabulary that has not yet been documented'.
