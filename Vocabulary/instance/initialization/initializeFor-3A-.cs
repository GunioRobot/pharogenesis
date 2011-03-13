initializeFor: anObject
	"Initialize the receiver to bear a vocabulary suitable for anObject"

	object := anObject.
	vocabularyName := #unnamed.
	categories := OrderedCollection new.
	methodInterfaces := IdentityDictionary new.
	self documentation: 'A vocabulary that has not yet been documented'.
